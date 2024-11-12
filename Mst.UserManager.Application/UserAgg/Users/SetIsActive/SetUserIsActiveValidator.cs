using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsActive;

public class SetUserIsActiveValidator : AbstractValidator<SetUserIsActive>
{
    public SetUserIsActiveValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must br grater than 0");    
    }
}
