using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CategoryDao
    {
          SieuThiOnline db = null;
          public CategoryDao()
        {
            db = new SieuThiOnline();
        }

        public List<Category> getListCategory()
        {
            return db.Categories.ToList();
        }

        public List<ProductViewModel> getListProductById(int categoryId)//lấy danh sách sản phẩm theo danh mục
        {
            var model = from a in db.Products
                        join b in db.Categories
                        on a.categories_id equals b.id
                        where a.categories_id == categoryId
                        select new ProductViewModel()
                        {
                            categoryName = b.name,
                            id = a.id,
                            name = a.name,
                            image = a.image,
                            price = a.price
                        };

            return model.ToList();
        }

        public Category getCategoryById(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
