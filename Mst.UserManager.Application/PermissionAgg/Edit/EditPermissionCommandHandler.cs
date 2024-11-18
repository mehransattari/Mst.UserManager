using Common.Application;
using Mst.UserManager.Domain.PermissionAgg.Repository;

namespace Mst.UserManager.Application.PermissionAgg.Edit;

public class EditPermissionCommandHandler : IBaseCommandHandler<EditPermissionCommand>
{
    public EditPermissionCommandHandler(IPermissionRepository permissionRepository)
    {
        PermissionRepository = permissionRepository;
    }

    private IPermissionRepository PermissionRepository { get; }

    public async Task<OperationResult> Handle(EditPermissionCommand request, CancellationToken cancellationToken)
    {
        var permission =await PermissionRepository.GetByIdTracking(request.Id);
        if (permission is null)
            return OperationResult.NotFound();
        permission.Edit(request.Name, request.Description);
        return OperationResult.Success();
    }
}
