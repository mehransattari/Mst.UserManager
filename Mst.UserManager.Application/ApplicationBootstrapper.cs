using Microsoft.Extensions.DependencyInjection;
using Mst.UserManager.Application.PermissionAgg;
using Mst.UserManager.Application.RoleAgg;
using Mst.UserManager.Application.UserAgg;
using Mst.UserManager.Domain.PermissionAgg.Services;
using Mst.UserManager.Domain.RoleAgg.Services;
using Mst.UserManager.Domain.UserAgg.Services;

namespace Mst.UserManager.Application;

public static class ApplicationBootstrapper
{
    public static void  InitApplication(IServiceCollection services)
    {
        services.AddScoped<IUserDomainService, UserDomainService>();
        services.AddScoped<IRoleDomainService, RoleDomainService>();
        services.AddScoped<IPermissionService, PermissionService>();
    }
}
