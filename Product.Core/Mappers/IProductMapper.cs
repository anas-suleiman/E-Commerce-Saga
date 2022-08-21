using Product.SDK.Models;

namespace Product.Core.Mappers
{
    public interface IProductMapper
    {
        DataAccess.Product ToDbModel(ProductSDKModel sdkModel);
        ProductSDKModel ToSDKModel(DataAccess.Product dbModel);
    }
}