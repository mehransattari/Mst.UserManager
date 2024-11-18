
using Common.Application;
using Mst.UserManager.Domain.PermissionAgg;
using Mst.UserManager.Domain.PermissionAgg.Repository;

namespace Mst.UserManager.Application.PermissionAgg.Create;

internal class CreatePermissionCommandHandler : IBaseCommandHandler<CreatePermissionCommand>
{
    public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
    {
        PermissionRepository = permissionRepository;
    }
    private IPermissionRepository PermissionRepository { get; }

    public async Task<OperationResult> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = new Permission(request.Name, request.Description);
        PermissionRepository.Add(permission);
        await PermissionRepository.Save();
        return OperationResult.Success();
    }
}
