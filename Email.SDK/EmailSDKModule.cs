using Common.Extensions;
using Email.SDK.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Email.SDK
{
    public static class EmailSDKModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSdkClient<IEmailClient, EmailClient>();
        }
    }
}
