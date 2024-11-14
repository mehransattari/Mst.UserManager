using Common.Application;
using Mst.UserManager.Domain.UserAgg.Repository;


namespace Mst.UserManager.Application.UserAgg.UserAddress.EditAddress;

public class EditAddressCommandHandler : IBaseCommandHandler<EditAddressCommand>
{
    public EditAddressCommandHandler(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    private IUserRepository UserRepository { get; }

    public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetByIdTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address = new Domain.UserAgg.UserAddress(request.Shire,
            request.City, 
            request.PostalCode,
            request.PostalAddress,
            request.PhoneNumber, 
            request.NationalCode);

        user.EditAddress(address, request.Id);
        await UserRepository.Save();

        return OperationResult.Success();
    }
}
