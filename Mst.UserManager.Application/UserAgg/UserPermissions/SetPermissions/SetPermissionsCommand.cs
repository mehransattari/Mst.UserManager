
using Common.Application;
using Mst.UserManager.Domain.UserAgg;

namespace Mst.UserManager.Application.UserAgg.UserPermissions.SetPermissions;

public class SetPermissionsCommand : IBaseCommand
{
    public long UserId { get; set; }
    public List<UserPermission> UserPermission { get; set; } = new();
}
