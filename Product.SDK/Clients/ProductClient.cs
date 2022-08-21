using Common.Base;
using Product.SDK.Models;

namespace Product.SDK
{
    public class ProductClient : BaseSdkClient, IProductClient
    {
        public ProductClient(HttpClient httpClient) : base(httpClient)
        {
            BaseUrl = ServiceUrl.ProductServiceUrl;
        }

        public async Task<List<ProductSDKModel>> GetAllProducts()
        {
            return await SendPlainRequest<List<ProductSDKModel>>(HttpMethod.Get, $"Product/GetAllProducts");
        }

        public async Task<int> CreateProduct(ProductSDKModel sdkModel)
        {
            return await SendJsonRequest<int>(HttpMethod.Post, $"Product/CreateProduct", sdkModel);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await SendJsonRequest<bool>(HttpMethod.Post, $"Product/DeleteProduct", productId);
        }

    }
}