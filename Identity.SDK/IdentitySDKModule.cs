using Common.Extensions;
using Identity.SDK.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.SDK
{
    public static class IdentitySDKModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSdkClient<IIdentityClient, IdentityClient>();
        }
    }
}
