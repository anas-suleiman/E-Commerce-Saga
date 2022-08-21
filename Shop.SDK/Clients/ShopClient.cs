using Common.Base;
using Shop.SDK.Models;

namespace Shop.SDK
{
    public class ShopClient : BaseSdkClient, IShopClient
    {
        public ShopClient(HttpClient httpClient) : base(httpClient)
        {
            BaseUrl = ServiceUrl.ShopServiceUrl;
        }

        public async Task<List<ShopSDKModel>> GetAllShops()
        {
            return await SendPlainRequest<List<ShopSDKModel>>(HttpMethod.Get, $"Shop/GetAllShops");
        }

        public async Task<int> CreateShop(ShopSDKModel sdkModel)
        {
            return await SendJsonRequest<int>(HttpMethod.Post, $"Shop/CreateShop", sdkModel);
        }

        public async Task<bool> DeleteShop(int shopId)
        {
            return await SendJsonRequest<bool>(HttpMethod.Post, $"Shop/DeleteShop", shopId);
        }
    }
}