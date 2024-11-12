using Common.Domain.Bases;
using Mst.UserManager.Domain.UserAgg;

namespace Mst.UserManager.Domain.RoleAgg;

public class Role : AggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = new();
    public List<RolePermission> RolePermissions { get; private set; } = new();
    private Role()
    {
    }
    public Role(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public void Edit(string name)
    {
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        Name = name;
    }

    public void SetPermissions(List<RolePermission> rolePermissions)
    {
        rolePermissions.ForEach(x => x.RoleId = Id);
        RolePermissions.Clear();
        RolePermissions.AddRange(rolePermissions);
    }

}
