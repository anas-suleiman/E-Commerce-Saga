using Common.Extensions;
using Microsoft.Extensions.DependencyInjection;


namespace Shop.SDK
{
    public static class ShopSDKModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSdkClient<IShopClient, ShopClient>();
        }
    }
}
