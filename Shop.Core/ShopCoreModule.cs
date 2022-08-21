using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Managers;
using Shop.Core.Mappers;

namespace Shop.Core
{
    public static class ShopCoreModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IShopMapper, ShopMapper>();
            services.AddTransient<IShopManager, ShopManager>();          
        }
    }
}
