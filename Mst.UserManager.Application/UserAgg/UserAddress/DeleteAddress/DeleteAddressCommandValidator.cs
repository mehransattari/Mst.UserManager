using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserAddress.DeleteAddress;

public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("AddressId باید بزرگتر از 0 باشد.");
    }
}