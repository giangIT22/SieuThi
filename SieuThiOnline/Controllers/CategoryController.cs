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
	}
}