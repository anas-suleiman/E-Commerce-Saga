using E_Commerce_Saga.Models;
using Email.SDK.Clients;
using Identity.SDK.Clients;
using Product.SDK;
using Shop.SDK;

namespace E_Commerce_Saga.Orchestrators
{
    public class RegistrationOrchestrator : IRegistrationOrchestrator
    {
        private readonly IEmailClient _emailClient;
        private readonly IIdentityClient _identityClient;
        private readonly IShopClient _shopClient;
        private readonly IProductClient _productClient;

        public RegistrationOrchestrator(IEmailClient emailClient,
            IIdentityClient identityClient, IShopClient shopClient, IProductClient productClient)
        {
            _emailClient = emailClient;
            _identityClient = identityClient;
            _shopClient = shopClient;
            _productClient = productClient;
        }

        public async Task<bool> Createregistration(RegistrationModel registrationModel)
        {
            var identityId = await _identityClient.CreateLogin(new Identity.SDK.Models.IdentitySDKModel
            {
                Email = registrationModel.Email,
                Password = registrationModel.Password,
            });

            if (identityId == default)
            {
                return default;
            }

            var shopId = await _shopClient.CreateShop(new Shop.SDK.Models.ShopSDKModel
            {
                IdentityId = identityId,
                Name = registrationModel.ShopName
            });

            if (shopId == default)
            {
                await RevertLoginCreation(identityId);
                return default;
            }

            var productId = await _productClient.CreateProduct(new Product.SDK.Models.ProductSDKModel
            {
                ShopId = shopId,
                Name = registrationModel.ProductName
            });

            if (productId == default)
            {
                var taskList = new List<Task> { RevertLoginCreation(identityId) , RevertShopCreation(shopId) };
                await Task.WhenAll(taskList);
                return default;
            }

            var emailId = await _emailClient.CreateEmail(new Email.SDK.Models.EmailSDKModel
            {
                Recipient = registrationModel.Email,
                Sent = false
            });

            if (emailId == default)
            {
                var taskList = new List<Task> { RevertLoginCreation(identityId), RevertShopCreation(shopId), RevertProductCreation(productId) };
                await Task.WhenAll(taskList);
                return default;
            }

            return true;
        }

        private async Task RevertLoginCreation(int identityId)
        {
            await _identityClient.DeleteLogin(identityId);
        }

        private async Task RevertShopCreation(int shopId)
        {
            await _shopClient.DeleteShop(shopId);
        }

        private async Task RevertProductCreation(int productId)
        {
            await _productClient.DeleteProduct(productId);
        }
    }
}
