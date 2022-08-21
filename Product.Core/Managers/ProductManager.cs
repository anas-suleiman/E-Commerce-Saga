using Microsoft.EntityFrameworkCore;
using Product.Core.Mappers;
using Product.DataAccess;
using Product.SDK.Models;

namespace Product.Core.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly ProductDbContext _context;
        private readonly IProductMapper _productMapper;

        public ProductManager(ProductDbContext context, IProductMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }

        public async Task<int> CreateProduct(ProductSDKModel sdkModel)
        {
            var dbModel = _productMapper.ToDbModel(sdkModel);
            _context.Add(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task<List<ProductSDKModel>> GetAllProducts()
        {
            return await _context.Products.AsNoTracking().Select(s => _productMapper.ToSDKModel(s)).ToListAsync();
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(f => f.Id == productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
