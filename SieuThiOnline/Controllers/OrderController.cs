using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            int orderId = new OrderDao().insertOrder(order);
            if (orderId > 0)
            {
                List<Product> products = (List<Product>)Session["cart"];
                foreach (var product in products)
                {
                    new OrderDao().insertOrderDetail(product, orderId);
                }
                ((List<Product>)Session["cart"]).Clear();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Order");
            

        }
        
	}
}