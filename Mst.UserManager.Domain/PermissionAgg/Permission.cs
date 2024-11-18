using Common.Domain.Bases;
using Mst.UserManager.Domain.RoleAgg;
using Mst.UserManager.Domain.UserAgg;
namespace Mst.UserManager.Domain.PermissionAgg;

public class Permission : AggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<RolePermission> RolePermissions { get; private set; } = new();
    public List<UserPermission> UserPermissions { get; private set; } = new();

    public Permission(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public void Edit(string name, string? description)
    {
        Name = name;
        Description = description;
    }

}
