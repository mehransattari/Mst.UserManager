
using Common.Application;

namespace Mst.UserManager.Application.PermissionAgg.Create;

public record CreatePermissionCommand(string Name, string? Description) : IBaseCommand;
