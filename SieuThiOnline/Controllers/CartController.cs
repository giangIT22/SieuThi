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
            ViewBag.cart =(List<Product>)Session["cart"];
            return View();
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
            return Json(new {
                count = lst.Count(),
                status = "Thêm sản phẩm thành công"
            });
        }
        [HttpPost]
        public JsonResult insertProduct(int id)
        {
            List<Product> lst = (List<Product>)Session["cart"];
            var product = new ProductDao().getProductById(id);
            if (lst.Count() == 0)
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
            return Json(new
            {
                count = lst.Count(),
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
	}
}