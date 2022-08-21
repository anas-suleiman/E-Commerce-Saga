using Email.Core.Managers;
using Email.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace Email.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailManager _emailManager;

        public EmailController(IEmailManager emailManager)
        {
            _emailManager = emailManager;
        }

        [HttpGet("GetAllEmails")]
        public async Task<List<EmailSDKModel>> GetAllEmails()
        {
            return await _emailManager.GetAllEmails();
        }

        [HttpPost("CreateEmail")]
        public async Task<int> CreateEmail([FromBody] EmailSDKModel sdkModel)
        {
            return await _emailManager.CreateEmail(sdkModel);
        }
    }
}