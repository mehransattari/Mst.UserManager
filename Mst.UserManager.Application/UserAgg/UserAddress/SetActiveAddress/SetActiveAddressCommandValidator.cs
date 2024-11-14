using FluentValidation;


namespace Mst.UserManager.Application.UserAgg.UserAddress.SetActiveAddress;

public class SetActiveAddressCommandValidator : AbstractValidator<SetActiveAddressCommand>
{
    public SetActiveAddressCommandValidator()
    {
        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("AddressId باید بزرگتر از 0 باشد.");

        RuleFor(x => x.UserId)
          .GreaterThan(0).WithMessage("UserId باید بزرگتر از 0 باشد.");
    }
}
