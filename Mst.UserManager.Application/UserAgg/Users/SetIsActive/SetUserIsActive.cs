using Common.Application;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsActive;

public record SetUserIsActive(long UserId) : IBaseCommand;
