
using Common.Application;
using Mst.UserManager.Domain.RoleAgg;
using Mst.UserManager.Domain.RoleAgg.Repository;

namespace Mst.UserManager.Application.RoleAgg.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        RoleRepository = roleRepository;
    }
    private IRoleRepository RoleRepository { get; }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Name, request.Description);

        var rolePermissions = new List<RolePermission>();

        request.Permissions.ForEach(per => rolePermissions
                                            .Add(new RolePermission(per.Id, role.Id)));

        role.SetPermissions(rolePermissions);

        RoleRepository.Add(role);

        await RoleRepository.Save();

        return OperationResult.Success();
    }
}

