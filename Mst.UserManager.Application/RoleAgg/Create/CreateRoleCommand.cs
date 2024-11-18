
using Common.Application;
using Mst.UserManager.Domain.PermissionAgg;

namespace Mst.UserManager.Application.RoleAgg.Create;

public record CreateRoleCommand(string Name, string Description, List<Permission> Permissions) : IBaseCommand;


