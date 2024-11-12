using Common.Application;

namespace Mst.UserManager.Application.UserAgg.Users.SetIsNotActive;

public record SetUserIsNotActive(long UserId):IBaseCommand;
