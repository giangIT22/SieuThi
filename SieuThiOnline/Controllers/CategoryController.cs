using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public PartialViewResult Menu()
        {
            var model = new CategoryDao().getListCategory();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult ListProduct()
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            ViewBag.products = new CategoryDao().getListProductById(id);
            var category = new CategoryDao().getCategoryById(id);
            return View(category);
        }
	}
}