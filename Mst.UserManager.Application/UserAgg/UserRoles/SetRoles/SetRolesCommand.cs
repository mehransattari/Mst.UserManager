using Common.Application;
using Mst.UserManager.Domain.UserAgg;

namespace Mst.UserManager.Application.UserAgg.UserRoles.SetRoles;

public class SetRolesCommand : IBaseCommand
{
    public long UserId { get; set; }
    public List<UserRole> UserRoles { get; set; } = new();
}

