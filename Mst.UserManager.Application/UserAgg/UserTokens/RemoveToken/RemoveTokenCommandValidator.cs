using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserTokens.RemoveToken;

public class RemoveTokenCommandValidator : AbstractValidator<RemoveTokenCommand>
{
    public RemoveTokenCommandValidator()
    {

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId باید بزرگتر از 0 باشد.");

        RuleFor(x => x.TokenId)
            .GreaterThan(0).WithMessage("TokenId باید بزرگتر از 0 باشد.");
    }
}
