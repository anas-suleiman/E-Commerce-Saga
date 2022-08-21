using Microsoft.AspNetCore.Mvc;
using Shop.Core.Managers;
using Shop.SDK.Models;

namespace Shop.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopManager _shopManager;

        public ShopController(IShopManager shopManager)
        {
            _shopManager = shopManager;
        }

        [HttpGet("GetAllShops")]
        public async Task<List<ShopSDKModel>> GetAllShops()
        {
            return await _shopManager.GetAllShops();
        }

        [HttpPost("CreateShop")]
        public async Task<int> CreateShop([FromBody] ShopSDKModel sdkModel)
        {
            return await _shopManager.CreateShop(sdkModel);
        }

        [HttpPost("DeleteShop")]
        public async Task<bool> DeleteShop([FromBody] int shopId)
        {
            return await _shopManager.DeleteShop(shopId);
        }
       

    }
}