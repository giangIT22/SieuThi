using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string image { set; get; }
        public int? price { set; get; }
        public string categoryName { set; get; }
    }
}
