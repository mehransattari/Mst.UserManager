using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsNotActive;

public class SetUserIsNotActiveValidator : AbstractValidator<SetUserIsNotActive>
{
    public SetUserIsNotActiveValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must br grater than 0");
    }
}
