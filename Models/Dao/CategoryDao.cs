using Models.EF;
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
    }
}
