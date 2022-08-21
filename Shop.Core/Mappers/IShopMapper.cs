using Shop.SDK.Models;

namespace Shop.Core.Mappers
{
    public interface IShopMapper
    {
        DataAcess.Shop ToDbModel(ShopSDKModel sdkModel);
        ShopSDKModel ToSDKModel(DataAcess.Shop dbModel);
    }
}