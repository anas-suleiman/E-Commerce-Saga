using E_Commerce_Saga.Orchestrators;
using Email.SDK;
using Identity.SDK;
using Product.SDK;
using Shop.SDK;

namespace E_Commerce_Saga
{
    public static class FrontEndWebModule
    {
        public static void RegisterSDKs(IServiceCollection services)
        {
            EmailSDKModule.RegisterServices(services);
            IdentitySDKModule.RegisterServices(services);
            ProductSDKModule.RegisterServices(services);
            ShopSDKModule.RegisterServices(services);

            services.AddTransient<IRegistrationOrchestrator, RegistrationOrchestrator>();
        }
    }
}
