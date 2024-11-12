using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsNotActive;

public class SetUserIsNotActiveHandler : IBaseCommandHandler<SetUserIsNotActive>
{
    public SetUserIsNotActiveHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get;}

    public async Task<OperationResult> Handle(SetUserIsNotActive request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.SetIsNotActive();
        return OperationResult.Success();
    }
}
