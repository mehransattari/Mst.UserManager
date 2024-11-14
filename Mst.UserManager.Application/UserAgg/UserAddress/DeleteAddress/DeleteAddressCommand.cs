using Common.Application;

namespace Mst.UserManager.Application.UserAgg.UserAddress.DeleteAddress;

public record DeleteAddressCommand(long UserId, long AddressId) : IBaseCommand;