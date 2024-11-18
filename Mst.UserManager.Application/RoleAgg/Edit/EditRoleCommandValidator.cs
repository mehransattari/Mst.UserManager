using FluentValidation;

namespace Mst.UserManager.Application.RoleAgg.Edit;

public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id should be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name should not be empty.")
            .MaximumLength(100) // Adjust length based on your requirements  
            .WithMessage("Name should not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500) // Optional: Limit the description length  
            .WithMessage("Description should not exceed 500 characters.");

        RuleFor(x => x.Permissions)
            .NotNull()
            .WithMessage("RolePermissions should not be null.")
            .Must(x => x.Count > 0)
            .WithMessage("There must be at least one role permission defined.");
    }
}  


