using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsActive;

internal class SetUserIsActiveHandler : IBaseCommandHandler<SetUserIsActive>
{
    public SetUserIsActiveHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }
    public async Task<OperationResult> Handle(SetUserIsActive request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.SetIsActive();
        return OperationResult.Success();
    }
}
