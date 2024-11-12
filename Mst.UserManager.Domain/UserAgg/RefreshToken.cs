using Common.Domain.Bases;

namespace Mst.UserManager.Domain.UserAgg;

public class RefreshToken : BaseEntity
{
    public string Token { get; private set; }
    public DateTime Expiration { get; private set; }
    public long UserId { get; internal set; }
    public User User { get; private set; }
    public bool IsRevoked { get; private set; }

    public RefreshToken(User user, string token, DateTime expiration)
    {
        User = user;
        Token = token;
        Expiration = expiration;
        IsRevoked = false;
    }

    public void Revoke() => IsRevoked = true;   
}
