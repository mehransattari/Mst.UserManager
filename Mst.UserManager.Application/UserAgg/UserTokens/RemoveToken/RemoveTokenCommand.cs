
using Common.Application;

namespace Mst.UserManager.Application.UserAgg.UserTokens.RemoveToken;

public record RemoveTokenCommand(long UserId, long TokenId) : IBaseCommand<string>;
