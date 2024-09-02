using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartSessionDemo.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddItems()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddItems(string item)
        {
            List<string> cart = Session["Cart"] as List<string>;

            if (cart == null)
            {
                cart = new List<string>();
                Session["Cart"] = cart;
            }

            cart.Add(item);
            return RedirectToAction("ViewItems");
        }

        public ActionResult ViewItems() {
            List<string> cart = Session["Cart"] as List<string>;
            if (cart == null)
            {
                cart = new List<string>();
            }
            ViewBag.Cart = cart;
            return View();
        }

        public ActionResult ClearCart()
        {
            Session["Cart"] = null;
            return RedirectToAction("ViewItems");
        }

        public ActionResult ExpiryPage()
        {
            return View();
        }
    }
}