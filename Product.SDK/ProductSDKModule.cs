using Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Product.SDK
{
    public static class ProductSDKModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSdkClient<IProductClient, ProductClient>();
        }
    }
}
