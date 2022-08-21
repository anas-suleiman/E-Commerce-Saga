using Identity.Core.Managers;
using Identity.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;

        public IdentityController(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        [HttpGet("GetAllLogins")]
        public async Task<List<IdentitySDKModel>> GeGetAllLoginst()
        {
            return await _identityManager.GetAllLogins();
        }

        [HttpPost("CreateLogin")]
        public async Task<int> CreateLogin([FromBody] IdentitySDKModel sdkModel)
        {
            return await _identityManager.CreateLogin(sdkModel);
        }

        [HttpPost("DeleteLogin")]
        public async Task<bool> DeleteLogin([FromBody] int identityId)
        {
            return await _identityManager.DeleteLogin(identityId);
        }
        
    }
}