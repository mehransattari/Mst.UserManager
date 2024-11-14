
using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.UserPermissions.SetPermissions;

public class SetPermissionsCommandHandler : IBaseCommandHandler<SetPermissionsCommand>
{
    public SetPermissionsCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }


    public async Task<OperationResult> Handle(SetPermissionsCommand request, CancellationToken cancellationToken)
    {

        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        user.SetPermissions(request.UserPermission);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
