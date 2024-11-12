using Common.Domain.Bases;

namespace Mst.UserManager.Domain.UserAgg;

public class AuditTrail : BaseEntity
{
    public string EntityName { get; private set; }
    public int EntityId { get; private set; }
    public string Action { get; private set; }
    public string OldValues { get; private set; }
    public string NewValues { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public int ChangedByUserId { get; private set; }
    public User ChangedBy { get; private set; }

    public AuditTrail(string entityName, int entityId, string action, string oldValues, string newValues, User changedBy)
    {
        EntityName = entityName;
        EntityId = entityId;
        Action = action;
        OldValues = oldValues;
        NewValues = newValues;
        ChangedAt = DateTime.Now;
        ChangedBy = changedBy;
    }
}
