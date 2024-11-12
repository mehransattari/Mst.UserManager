using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.Users.SetLastLogin;

public class SetUserLastLoginValidator : AbstractValidator<SetUserLastLogin>
{
    public SetUserLastLoginValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must br grater than 0");
    }
}