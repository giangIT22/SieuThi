using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return db.Products.Where(x => x.categories_id == id).Take(5).ToList();
        }

        //public List<Product> getListProductById(int id)
        //{
        //    return db.Products.Join(// outer sequence 
        //              db.Categories,  // inner sequence 
        //              x => x.categories_id,    // outerKeySelector
        //              y => y.id,  // innerKeySelector
        //              (x, y) => new  // result selector
        //              {
        //                  productList = x,
        //                  categoryName = y.name
        //              });
        //}


        public Product getProductById(int id)
        {
            return db.Products.Find(id);
        }

        public Product getProduct(int id)
        {
            return (from pr in db.Products where pr.id == id select pr).FirstOrDefault();
        }
    }
}
