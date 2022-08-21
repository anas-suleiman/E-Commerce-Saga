using Microsoft.EntityFrameworkCore;
using Shop.Core.Mappers;
using Shop.DataAcess;
using Shop.SDK.Models;

namespace Shop.Core.Managers
{
    public class ShopManager : IShopManager
    {
        private readonly ShopDbContext _context;
        private readonly IShopMapper _mapper;
        public ShopManager(ShopDbContext context, IShopMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateShop(ShopSDKModel sdkModel)
        {
            var dbModel = _mapper.ToDbModel(sdkModel);
            _context.Add(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task<List<ShopSDKModel>> GetAllShops()
        {
            return await _context.Shops.AsNoTracking().Select(s => _mapper.ToSDKModel(s)).ToListAsync();
        }

        public async Task<bool> DeleteShop(int shopId)
        {
            var shop = await _context.Shops.FirstOrDefaultAsync(f => f.Id == shopId);
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
