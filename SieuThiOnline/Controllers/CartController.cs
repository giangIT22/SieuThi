using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SieuThiOnline.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private  List<Product> products = new List<Product>();
        
        public ActionResult Index()
        {
            List<Product> lst = (List<Product>)Session["cart"];
            int ? sum = 0;
            
            ViewBag.cart =(List<Product>)Session["cart"];
            foreach (var item in lst)
            {
                sum += item.qty;
            }

            ViewBag.qty = sum;
            return View();
        }

        public PartialViewResult GetCount()
        {
            if (Session["cart"] != null)
            {
                ViewBag.count = ((List<Product>)Session["cart"]).Count();
            }
            else
            {
                ViewBag.count = 0;
            }
            List<Product> lst = (List<Product>)Session["cart"];
            var sumPrice = 0;
            foreach (var item in lst)
            {
                   sumPrice += Convert.ToInt32(Convert.ToDecimal(item.qty * item.price));
            }

            ViewBag.price = sumPrice.ToString("#,##0");
            return PartialView();
        }


        [HttpPost]
        public JsonResult insertCart(int id, int qty)
        {
            List<Product> lst = (List<Product>)Session["cart"];
            //products = (List<Product>)Session["cart"];
            var product = new ProductDao().getProductById(id);
            if (lst.Count() == 0)
            {
                product.qty = qty;
                lst.Add(product);
            }
            else
            {
                var flag = false;
                foreach (var item in lst)
                {
                    if (item.id == product.id)
                    {
                        item.qty += qty;
                        flag = true;
                        break;
                    } 
                    
                }
                if (flag ==false)
                {
                    product.qty = qty;
                    lst.Add(product);
                }
           
                
            }

            Session["cart"] = lst;
            products = (List<Product>)Session["cart"];
            return Json(new
            {
                count = products.Count().ToString(),
                status = "Thêm sản phẩm thành công"
            });
        }
        [HttpPost]
        public JsonResult insertProduct(int id)
        {
            List<Product> lst = (List<Product>)Session["cart"];
            var product = new ProductDao().getProductById(id);
            if (lst == null)
            {
                product.qty = 1;
                lst.Add(product);
            }
            else
            {
                var flag = false;
                foreach (var item in lst)
                {
                    if (item.id == product.id)
                    {
                        item.qty += 1;
                        flag = true;
                        break;
                    }

                }
                if (flag == false)
                {
                    product.qty = 1;
                    lst.Add(product);
                }


            }

            Session["cart"] = lst;
            products = (List<Product>)Session["cart"];
            return Json(new
            {
                count =products.Count().ToString(),
                status = "Thêm sản phẩm thành công"
            });
        }
        
        [HttpPost]
        public ActionResult UpdateCart(FormCollection formCollection)
        {
            List<Product> products = (List<Product>)Session["cart"];
            int i = 0;
            string[] value = new string[formCollection.Count];
            foreach (var key in formCollection.AllKeys)
            {
                var id = Convert.ToInt32(key);
                foreach (var item in products)
                {
                    if (item.id == id)
                    {
                        item.qty = Convert.ToInt32(formCollection[key]);
                    }
                }
            }
            Session["cart"] = products;
            return RedirectToAction("Index", "Cart");
        }

        public JsonResult checkLogin()
        {
            var status = true;
            UserLogin user = (UserLogin)Session["user"];
            if (user.UserName ==null)
            {
               status = false;
            }
            else{
                status = true;
            }
            return Json(new
            {
                status = status
            });
        }

        [HttpGet]
        public ActionResult DeleteCart()
        {
            List<Product> products = (List<Product>)Session["cart"];
            int id = Convert.ToInt32(Request.QueryString["id"]);
            foreach (var product in products)
            {
                if (product.id == id)
                {
                    products.Remove(product);
                    break;
                }
            }
            return RedirectToAction("Index", "Cart");
        }
	}
}