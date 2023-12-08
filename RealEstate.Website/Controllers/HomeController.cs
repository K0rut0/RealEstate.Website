using Microsoft.AspNetCore.Mvc;
using RealEstate.Website.Models;
using RealEstateManager;
using RealEstateManager.Context.DBModel;
using System.Diagnostics;

namespace RealEstate.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignResult()
        {
            return View();
        }

        public IActionResult Home()
        {
            PropertyManager manager = new PropertyManager();
            List<BPropsViewModel> list = manager.GetAll();
            List<PropsViewModel> result = new List<PropsViewModel>();
            for(int i = 0; i < list.Count; i++)
            {
                PropsViewModel mod = new PropsViewModel();
                mod.property_price = list[i].property_price;
                mod.property_name = list[i].property_name;
                mod.property_location = list [i].property_location;
                mod.property_type = list[i].property_type;
                mod.property_purchase_tax = list[i].property_purchase_tax;
                mod.property_anual_tax = list[i].property_anual_tax;
                result.Add(mod);
            }
            ViewData["MyData"] = result; // Send this list to the view
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}