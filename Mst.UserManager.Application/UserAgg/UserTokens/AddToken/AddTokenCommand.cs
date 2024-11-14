
using Common.Application;

namespace Mst.UserManager.Application.UserAgg.UserTokens.AddToken;

public record AddTokenCommand(
    long UserId,
    string HashJwtToken,
    string HashRefreshToken,
    DateTime TokenExpireDate,
    DateTime RefreshTokenExpireDate,
    string Device
) : IBaseCommand;
