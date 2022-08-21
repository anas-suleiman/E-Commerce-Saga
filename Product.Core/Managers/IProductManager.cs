using Product.SDK.Models;

namespace Product.Core.Managers
{
    public interface IProductManager
    {
        Task<int> CreateProduct(ProductSDKModel sdkModel);
        Task<List<ProductSDKModel>> GetAllProducts();
        Task<bool> DeleteProduct(int productId);
    }
}