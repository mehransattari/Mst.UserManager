using Common.Application;
using Mst.UserManager.Domain.PermissionAgg;

namespace Mst.UserManager.Application.RoleAgg.Edit;

public record EditRoleCommand(long Id, string Name, string? Description, List<Permission> Permissions) :IBaseCommand;


