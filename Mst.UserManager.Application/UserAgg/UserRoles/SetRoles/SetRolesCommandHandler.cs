using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.UserRoles.SetRoles;

public class SetRolesCommandHandler : IBaseCommandHandler<SetRolesCommand>
{
    public SetRolesCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }


    public async Task<OperationResult> Handle(SetRolesCommand request, CancellationToken cancellationToken)
    {

        var user = await UserRepository.GetByIdTracking(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        user.SetRoles(request.UserRoles);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}

