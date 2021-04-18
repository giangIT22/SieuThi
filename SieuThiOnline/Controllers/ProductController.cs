using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public PartialViewResult List()
        {
            var product = new ProductDao();
            ViewBag.meat = product.getListProductByIdCategory(1);
            ViewBag.cake = product.getListProductByIdCategory(2);
            ViewBag.drink = product.getListProductByIdCategory(3);
            ViewBag.veg = product.getListProductByIdCategory(4);
            ViewBag.milk = product.getListProductByIdCategory(5);
            return PartialView();
        }

        //public ActionResult list()
        //{
        //    int id = Convert.ToInt32(Request.QueryString["id"]);
        //    var products = new ProductDao().getListProductById(id);
        //    return View();
        //}

        public ActionResult detail()
        {
            int productId = Convert.ToInt32(Request.QueryString["id"]);
            var product = new ProductDao().getProductById(productId);
            return View(product);
        }


        public ActionResult ListProduct()
        {
            ViewBag.products = new ProductDao().getListProduct();
            return View();
        }
	}
}