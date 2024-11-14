using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;

namespace Mst.UserManager.Application.UserAgg.UserAddress.AddAddress;

public class AddAddressCommandHandler : IBaseCommandHandler<AddAddressCommand>
{
    public AddAddressCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get;}
    public async Task<OperationResult> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdTracking(request.UserId);

        if (user == null)
            return OperationResult.NotFound();

        var address = new Domain.UserAgg.UserAddress(request.Shire, request.City,
            request.PostalCode, request.PostalAddress,
            request.PhoneNumber, request.NationalCode);

        user.AddAddress(address);
        await UserRepository.Save();
        return OperationResult.Success();
    }
}
