using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserPermissions.SetPermissions;

public class SetPermissionsCommandValidator : AbstractValidator<SetPermissionsCommand>
{
    public SetPermissionsCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0)
            .WithMessage("{UserId} نباید کمتر از 0 باشد");

        RuleFor(x => x.UserPermission)
           .NotEmpty().WithMessage("لیست نقش‌ها نباید خالی باشد.");
    }
}
