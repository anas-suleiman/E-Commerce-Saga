using Product.SDK.Models;

namespace Product.Core.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public DataAccess.Product ToDbModel(ProductSDKModel sdkModel)
        {
            return new DataAccess.Product
            {
                Id = sdkModel.Id,
                Name = sdkModel.Name,
                ShopId = sdkModel.ShopId
            };
        }

        public ProductSDKModel ToSDKModel(DataAccess.Product dbModel)
        {
            return new ProductSDKModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                ShopId = dbModel.ShopId
            };
        }
    }
}
