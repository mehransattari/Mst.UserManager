using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.SetLastLogin;

public class SetUserLastLoginHandler : IBaseCommandHandler<SetUserLastLogin>
{
    public SetUserLastLoginHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(SetUserLastLogin request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.SetLastLogin();
        return OperationResult.Success();
    }
}
