using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Mst.UserManager.Application.UserAgg.Users.Edit;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty().WithMessage("First name is required.")
        .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 20).WithMessage("Username must be between 3 and 20 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Invalid gender specified.");

        RuleFor(x => x.ProfilePhotoUrl)
           .Must(HaveValidFile).WithMessage("Avatar must be a valid image file.")
           .When(x => x.ProfilePhotoUrl != null).JustImageFile(); 
    }


    private bool HaveValidFile(IFormFile? file)
    {
        var validTypes = new[] { "image/jpeg", "image/png", "image/gif" };
        return file != null && validTypes.Contains(file.ContentType);
    }
}