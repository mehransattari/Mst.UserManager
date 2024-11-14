using Common.Application;


namespace Mst.UserManager.Application.UserAgg.UserAddress.SetActiveAddress;


public record SetActiveAddressCommand(long UserId, long AddressId) : IBaseCommand;
