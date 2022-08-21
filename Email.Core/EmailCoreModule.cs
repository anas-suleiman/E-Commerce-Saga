using Email.Core.Managers;
using Email.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Email.Core
{
    public static class EmailCoreModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEmailMapper, EmailMapper>();
            services.AddTransient<IEmailManager, EmailManager>();          
        }
    }
}
