using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstateManager;
using RealEstateManager.Context.DBModel;
using RealEstateManager.Derived;
using System.Reflection.PortableExecutable;

namespace RealEstate.Website.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Bid(string bidAmount, string propertyName, string propertyOwner, string bidder)
        {
            PropertyManager manager = new PropertyManager();
            manager.bid(bidAmount, propertyName, propertyOwner, bidder);
            return RedirectToAction("Home", "Home");
        }
        [HttpPost]
        public IActionResult SellProperty(string propertyName, string propertyLocation, string propertyType, string propertyPrice)
        {
            PropertyManager manager = new PropertyManager();
            if(Int32.Parse(propertyType) == 1)
            {
                var realEstate = new properties_table();
                var prop = new Industrial();
                prop.cost = Int32.Parse(propertyPrice);
                double anumTax = prop.AnnualTax;
                double purchTax = prop.PurchaseTax;
                realEstate.property_price = prop.cost.ToString();
                realEstate.property_purchase_tax = prop.CompPurchaseTax(prop.cost).ToString();
                realEstate.property_anual_tax = prop.CompAnnualTax(prop.cost).ToString();
                realEstate.property_name = propertyName;
                realEstate.property_location = propertyLocation;
                realEstate.property_type = Int32.Parse(propertyType);
                realEstate.property_owner = HttpContext.Session.GetString("SessionID");
                manager.SellProperty(realEstate);
           
            } else
            {
                var realEstate = new properties_table();
                var prop = new Commercial();
                prop.cost = Int32.Parse(propertyPrice);
                double anumTax = prop.AnnualTax;
                double purchTax = prop.PurchaseTax;
                realEstate.property_price = prop.cost.ToString();
                realEstate.property_purchase_tax = prop.CompPurchaseTax(prop.cost).ToString();
                realEstate.property_anual_tax = prop.CompAnnualTax(prop.cost).ToString();
                realEstate.property_name = propertyName;
                realEstate.property_location = propertyLocation;
                realEstate.property_type = Int32.Parse(propertyType);
                realEstate.property_owner = HttpContext.Session.GetString("SessionID");
                manager.SellProperty(realEstate);
            }
            
            return RedirectToAction("Home", "Home");
        }
    }
}
