using Shop.SDK.Models;

namespace Shop.Core.Managers
{
    public interface IShopManager
    {
        Task<int> CreateShop(ShopSDKModel sdkModel);
        Task<List<ShopSDKModel>> GetAllShops();
        Task<bool> DeleteShop(int shopId);
    }
}