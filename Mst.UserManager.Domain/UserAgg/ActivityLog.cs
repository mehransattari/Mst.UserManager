using Common.Domain.Bases;

namespace Mst.UserManager.Domain.UserAgg;

public class ActivityLog : BaseEntity
{
    public long UserId { get; internal set; }
    public User User { get; private set; }
    public string Action { get; private set; }
    public string Details { get; private set; }
    public DateTime Timestamp { get; private set; }

    public ActivityLog(User user, string action, string details)
    {
        User = user;
        Action = action;
        Details = details;
        Timestamp = DateTime.Now;
    }
}
