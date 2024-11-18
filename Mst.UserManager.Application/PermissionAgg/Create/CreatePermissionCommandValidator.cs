using FluentValidation;

namespace Mst.UserManager.Application.PermissionAgg.Create;

public class CreatePermissionCommandValidator :  AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Name should not be empty.")
              .MaximumLength(100) // Adjust the length based on requirements  
              .WithMessage("Name should not exceed 100 characters.");

        RuleFor(x => x.Description)
             .MaximumLength(500) // Optional: limit description length  
             .WithMessage("Description should not exceed 500 characters.");
    }
}
