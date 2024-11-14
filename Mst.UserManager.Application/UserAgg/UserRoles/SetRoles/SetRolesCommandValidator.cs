using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserRoles.SetRoles;

public class SetRolesCommandValidator : AbstractValidator<SetRolesCommand>
{
    public SetRolesCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0)
            .WithMessage("{UserId} نباید کمتر از 0 باشد");

        RuleFor(x => x.UserRoles)
           .NotEmpty().WithMessage("لیست نقش‌ها نباید خالی باشد.");
    }
}

