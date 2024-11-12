using Common.Application;

namespace Mst.UserManager.Application.UserAgg.Users.SetLastLogin;

public record SetUserLastLogin(long UserId) : IBaseCommand;
