using Microsoft.AspNetCore.Mvc;
using Product.Core.Managers;
using Product.SDK.Models;

namespace Product.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("GetAllProducts")]
        public async Task<List<ProductSDKModel>> GetAllProducts()
        {
            return await _productManager.GetAllProducts();
        }

        [HttpPost("CreateProduct")]
        public async Task<int> CreateProduct([FromBody] ProductSDKModel sdkModel)
        {
            return await _productManager.CreateProduct(sdkModel);
        }

        [HttpPost("DeleteProduct")]
        public async Task<bool> DeleteProduct([FromBody] int productId)
        {
            return await _productManager.DeleteProduct(productId);
        }      
    }
}