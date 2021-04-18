using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class HomeController : Controller
    {
        List<Product> products = new List<Product>();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Login()
        {
            ViewBag.name = ((UserLogin)Session["user"]).fullName ?? null; ;
            return PartialView();
        
        }

        [HttpPost]
        public ActionResult Search(FormCollection f)
        {
            ViewBag.products = new ProductDao().searchProduct(f["product-name"].ToString());
            return View();
        }
       
	}
}