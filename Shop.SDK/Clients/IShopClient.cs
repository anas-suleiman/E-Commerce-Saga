using Shop.SDK.Models;

namespace Shop.SDK
{
    public interface IShopClient
    {
        Task<List<ShopSDKModel>> GetAllShops();
        Task<int> CreateShop(ShopSDKModel sdkModel);
        Task<bool> DeleteShop(int shopId);
    }
}