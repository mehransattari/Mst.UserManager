using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.Users.Remove;

public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>   
{
    public RemoveUserCommandValidator()
    {
        RuleFor(x => x.UserId)
         .GreaterThan(0).WithMessage("UserId must be greater than 0.");
    }
}
