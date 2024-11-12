using Common.Domain.Bases;

namespace Mst.UserManager.Domain.UserAgg;

public class UserPermission : BaseEntity
{

    public UserPermission(long permissionId)
    {
        PermissionId = permissionId;
    }

    public long UserId { get; internal set; }
    public long PermissionId { get; private set; }
}
