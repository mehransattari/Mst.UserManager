using Common.Domain.Bases;

namespace Mst.UserManager.Domain.RoleAgg;

public class RolePermission : BaseEntity
{
    public long RoleId { get; internal set; }

    public long PermissionId { get; private set; }

    public RolePermission(long permissionId, long roleId)
    {
        PermissionId = permissionId;
        RoleId = roleId;
    }
}
