using Common.Application.Validation;
using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.Users.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(command => command.UserId)
         .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(r => r.CurrentPassword)
          .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور فعلی"))
          .MinimumLength(5).WithMessage(ValidationMessages.required("کلمه عبور فعلی"));

        RuleFor(r => r.NewPassword)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور فعلی"))
            .MinimumLength(5).WithMessage(ValidationMessages.required("کلمه عبور فعلی"));
    }

}
