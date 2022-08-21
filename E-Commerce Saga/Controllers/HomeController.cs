using E_Commerce_Saga.Models;
using E_Commerce_Saga.Orchestrators;
using Email.SDK.Clients;
using Identity.SDK.Clients;
using Microsoft.AspNetCore.Mvc;
using Product.SDK;
using Shop.SDK;
using System.Diagnostics;

namespace E_Commerce_Saga.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailClient _emailClient;
        private readonly IIdentityClient _identityClient;
        private readonly IShopClient _shopClient;
        private readonly IProductClient _productClient;
        private readonly IRegistrationOrchestrator _registrationOrchestrator;
        public HomeController(ILogger<HomeController> logger, IEmailClient emailClient, 
            IIdentityClient identityClient, IShopClient shopClient, IProductClient productClient,
            IRegistrationOrchestrator registrationOrchestrator)
        {
            _logger = logger;
            _emailClient = emailClient;
            _identityClient = identityClient;
            _shopClient = shopClient;
            _productClient = productClient;
            _registrationOrchestrator = registrationOrchestrator;
        }

        public async Task<IActionResult> Index()
        {
            //await _emailClient.GetAllEmails();
            //await _identityClient.GetAllEmails();
            //await _shopClient.GetAllShops();
            //await _productClient.GetAllProducts();

            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationModel registrationModel)
        {
            return Json(new { success = await _registrationOrchestrator.Createregistration(registrationModel) });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}