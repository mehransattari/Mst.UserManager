using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.UserAddress.DeleteAddress;

public class DeleteAddressCommandHandler : IBaseCommandHandler<DeleteAddressCommand>
{
    public DeleteAddressCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdTracking(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        user.DeleteAddress(request.AddressId);

        await UserRepository.Save();

        return OperationResult.Success();
    }
}
