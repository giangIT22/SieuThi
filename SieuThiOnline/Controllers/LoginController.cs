using Models.Dao;
using SieuThiOnline.Common;
using SieuThiOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Login/
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var dao = new UserDao();
            var result = dao.login(model.UserName, model.Password);
            if (result)
            {
                var user = dao.getUserByUsername(model.UserName);
                var userSession = new UserLogin();
                userSession.UserId = user.id;
                userSession.UserName = user.username;
                userSession.fullName = user.fullname;
                Session["user"] = userSession;
                return RedirectToAction("Index", "Order");
            }
            else
            {
                ViewBag.error = "Thông tin đăng nhập không đúng" ?? "";
                return View();
            }           
        }
	}
}