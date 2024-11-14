using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserTokens.AddToken;

public class AddTokenCommandValidator : AbstractValidator<AddTokenCommand>  
{
    public AddTokenCommandValidator()
    {
        RuleFor(x => x.UserId)
       .GreaterThan(0).WithMessage("UserId باید بزرگتر از 0 باشد.");

        RuleFor(x => x.HashJwtToken)
            .NotEmpty().WithMessage("JWT Token نباید خالی باشد.")
            .Length(10, 500).WithMessage("JWT Token باید بین 10 تا 500 کاراکتر باشد.");

        RuleFor(x => x.HashRefreshToken)
            .NotEmpty().WithMessage("Refresh Token نباید خالی باشد.")
            .Length(10, 500).WithMessage("Refresh Token باید بین 10 تا 500 کاراکتر باشد.");

        RuleFor(x => x.TokenExpireDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("تاریخ انقضای توکن باید در آینده باشد.");

        RuleFor(x => x.RefreshTokenExpireDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("تاریخ انقضای Refresh Token باید در آینده باشد.")
            .GreaterThan(x => x.TokenExpireDate).WithMessage("تاریخ انقضای Refresh Token باید بعد از تاریخ انقضای توکن باشد.");

        RuleFor(x => x.Device)
            .NotEmpty().WithMessage("شناسه دستگاه نباید خالی باشد.");
    }
}
