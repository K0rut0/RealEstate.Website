using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using RealEstateManager;
using RealEstateManager.Context.DBModel;
using RealEstateManager.Derived;
using System.Security.Cryptography.X509Certificates;

namespace RealEstate.Website.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string username, string password, string userType)
        {
            UserManager manager = new UserManager();
            int uType = Int32.Parse(userType);
            bool res = manager.SignUp(username, password, uType);
            if (res)
            {
                TempData["SignResult"] = "Sign-Up was successful!";
                return RedirectToAction("SignResult", "Home");
            } else
            {
                TempData["SignResult"] = "There was a problem signing up.";
                return RedirectToAction("SignResult", "Home");
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password) 
        {
            UserManager manager = new UserManager();
            bool log = manager.Login(username, password);
            if (log)
            {
                var userInfo = manager.GetUserInfo(username);
                if(userInfo.user_type == 1 || userInfo.user_type == 3)
                {
                    Buyer user = new Buyer();
                    user.canBuy = true;
                    buyer_table info = manager.GetBuyerInfo(username);
                    string bid = info.bids.ToString();
                    //user.bids = Int32.Parse(bid);
                    //user.balance = Int32.Parse(info.balance);
                    HttpContext.Session.SetString("SessionID", userInfo.user_name);
                    HttpContext.Session.SetString("UserType", userInfo.user_type.ToString());
                    //HttpContext.Session.SetString("UserBalance", user.balance.ToString());
                    //HttpContext.Session.SetString("UserBids", user.bids.ToString());
                    HttpContext.Session.SetString("UserBuys", user.canBuy.ToString());
                } else if (userInfo.user_type == 2 || userInfo.user_type == 3)
                {
                    Seller user = new Seller();
                    seller_table seller = manager.GetSellerInfo(username);
                    user.canSell = true;
                    user.AgencyName = seller.agency_name;
                    user.PropertyCount = seller.property_count;
                    HttpContext.Session.SetString("SessionID", userInfo.user_name);
                    HttpContext.Session.SetString("UserType", userInfo.user_type.ToString());
                    HttpContext.Session.SetString("AgencyName", user.AgencyName);
                    HttpContext.Session.SetString("PropCount", user.PropertyCount.ToString());
                }
                

            }
            return  RedirectToAction("Home", "Home");
        }
    }
}
