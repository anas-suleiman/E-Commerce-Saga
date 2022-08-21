using Shop.SDK.Models;

namespace Shop.Core.Mappers
{
    public class ShopMapper : IShopMapper
    {
        public DataAcess.Shop ToDbModel(ShopSDKModel sdkModel)
        {
            return new DataAcess.Shop
            {
                Id = sdkModel.Id,
                IdentityId = sdkModel.IdentityId,
                Name = sdkModel.Name
            };
        }

        public ShopSDKModel ToSDKModel(DataAcess.Shop dbModel)
        {
            return new ShopSDKModel
            {
                Id = dbModel.Id,
                IdentityId = dbModel.Id,
                Name = dbModel.Name
            };
        }
    }
}
