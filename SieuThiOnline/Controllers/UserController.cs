using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var dao = new UserDao();
            var id = dao.Insert(user);
            if (id > 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.error = "Tài khoản đã tồn tại" ?? "";
                return View();
            }
        }
	}
}