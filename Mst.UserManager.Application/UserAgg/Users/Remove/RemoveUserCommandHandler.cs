using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.Remove;

public class RemoveUserCommandHandler : IBaseCommandHandler<RemoveUserCommand>
{
    public RemoveUserCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        await UserRepository.DeleteAsync(user);

        return OperationResult.Success();
    }
}
