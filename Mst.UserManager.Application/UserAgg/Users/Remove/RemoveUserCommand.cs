using Common.Application;
using Common.Domain.Bases;

namespace Mst.UserManager.Application.UserAgg.Users.Remove;

public record RemoveUserCommand(long UserId) : IBaseCommand;
