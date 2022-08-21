using Microsoft.Extensions.DependencyInjection;
using Product.Core.Managers;
using Product.Core.Mappers;

namespace Product.Core
{
    public static class ProductCoreModule
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IProductMapper, ProductMapper>();
            services.AddTransient<IProductManager, ProductManager>();          
        }
    }
}
