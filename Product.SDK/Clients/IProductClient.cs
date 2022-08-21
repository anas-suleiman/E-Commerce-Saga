using Product.SDK.Models;

namespace Product.SDK
{
    public interface IProductClient
    {
        Task<List<ProductSDKModel>> GetAllProducts();
        Task<int> CreateProduct(ProductSDKModel sdkModel);
        Task<bool> DeleteProduct(int productId);
    }
}