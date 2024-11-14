using FluentValidation;

namespace Mst.UserManager.Application.UserAgg.UserAddress.AddAddress;

public class AddAddressCommandValidator: AbstractValidator<AddAddressCommand>
{
    public AddAddressCommandValidator()
    {
        RuleFor(command => command.UserId)
            .GreaterThan(0).WithMessage("UserId باید بزرگتر از 0 باشد."); 

        RuleFor(command => command.Shire)
            .NotEmpty().WithMessage("شهرستان نباید خالی باشد.")
            .MaximumLength(100).WithMessage("شهرستان نمی‌تواند بیشتر از 100 کاراکتر باشد.");

        RuleFor(command => command.City)
            .NotEmpty().WithMessage("شهر نباید خالی باشد.")
            .MaximumLength(100).WithMessage("شهر نمی‌تواند بیشتر از 100 کاراکتر باشد.");

        RuleFor(command => command.PostalCode)
            .NotEmpty().WithMessage("کد پستی نباید خالی باشد.")
            .Matches(@"^\d{5}(?:[-\s]\d{4})?$").WithMessage("کد پستی باید یک رشته عددی 5 رقمی یا 9 رقمی باشد.");

        RuleFor(command => command.PostalAddress)
            .NotEmpty().WithMessage("آدرس پستی نباید خالی باشد.")
            .MaximumLength(450).WithMessage("آدرس پستی نمی‌تواند بیشتر از 450 کاراکتر باشد.");

        RuleFor(command => command.NationalCode)
            .NotEmpty().WithMessage("کد ملی نباید خالی باشد.")
            .Matches(@"^\d{10}$").WithMessage("کد ملی باید 10 رقم باشد.");
    }
}
