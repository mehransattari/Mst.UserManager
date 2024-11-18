using Common.Application;

namespace Mst.UserManager.Application.PermissionAgg.Edit;

public record EditPermissionCommand(long Id, string Name, string? Description) : IBaseCommand;
