using Common.Application;
using Mst.UserManager.Domain.RoleAgg;
using Mst.UserManager.Domain.RoleAgg.Repository;

namespace Mst.UserManager.Application.RoleAgg.Edit;

public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    public EditRoleCommandHandler(IRoleRepository roleRepository)
    {
        RoleRepository = roleRepository;
    }

    private IRoleRepository RoleRepository { get;}


    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await RoleRepository.GetByIdTracking(request.Id);

        if (role is null)
            return OperationResult.NotFound();

        role.Edit(role.Name);

        List<RolePermission> rolePermissions = new();

        request.Permissions.ForEach(permission => rolePermissions
                                    .Add(new RolePermission(role.Id, permission.Id)));

        role.SetPermissions(rolePermissions);

        await RoleRepository.Save();

        return OperationResult.Success();
    }
}


