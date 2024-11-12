using Common.Application;

namespace Mst.UserManager.Application.UserAgg.Users.ChangePassword;

public record ChangePasswordCommand(long UserId, string CurrentPassword, string NewPassword) : IBaseCommand;
