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
        SetName(name);
        Description = description;
    }

    public void Edit(string name, string? description = null)
    {
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        SetName(name);

        if (description != null)
        {
            Description = description;
        }
    }

    public void SetPermissions(List<RolePermission> rolePermissions)
    {
        if (rolePermissions == null || !rolePermissions.Any())
        {
            throw new InvalidDomainDataException("Role permissions cannot be null or empty.");
        }

        rolePermissions.ForEach(x => x.RoleId = Id);
        RolePermissions.Clear();
        RolePermissions.AddRange(rolePermissions);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        }
        Name = name;
    }
}
