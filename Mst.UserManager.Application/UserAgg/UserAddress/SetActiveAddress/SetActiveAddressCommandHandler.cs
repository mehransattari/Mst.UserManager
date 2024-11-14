using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;


namespace Mst.UserManager.Application.UserAgg.UserAddress.SetActiveAddress;

public class SetActiveAddressCommandHandler : IBaseCommandHandler<SetActiveAddressCommand>
{
    public SetActiveAddressCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(SetActiveAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.SetActiveAddress(request.AddressId);
        await UserRepository.Save();
        return OperationResult.Success();
    }
}
