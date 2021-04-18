using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModel;

namespace Models.Dao
{
    public class ProductDao
    {
         SieuThiOnline db = null;
        public ProductDao()
        {
            db = new SieuThiOnline();
        }

        public List<Product> getListProductByIdCategory(int id)
        {
            return db.Products.Where(x => x.categories_id == id).Take(6).ToList();
        }

        public Product getProductById(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> getListProduct()
        {
            return db.Products.ToList();
        }

        public Product getProduct(int id)//lấy ra 1 sản phẩm
        {
            return (from pr in db.Products where pr.id == id select pr).FirstOrDefault();
        }

        public List<Product> searchProduct(string searchString)//tìm kiếm sản phẩm
        {

            var products = from pr in db.Products // lấy toàn bộ liên kết
                        select pr;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                products = products.Where(s => s.name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return products.ToList();
        }

    }
}
