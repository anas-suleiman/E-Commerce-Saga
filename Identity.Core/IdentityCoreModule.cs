using Identity.Core.Managers;
using Identity.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Core
{
    public static class IdentityCoreModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IIdentityMapper, IdentityMapper>();
            services.AddTransient<IIdentityManager, IdentityManager>();          
        }
    }
}
