using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class OrderDao
    {
        SieuThiOnline db = null;
        OrderDetail entity = new OrderDetail();
        public OrderDao()
        {
            db = new SieuThiOnline();
        }

        public int insertOrder(Order entity)
        {
            entity.created_at = DateTime.Now;
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public void insertOrderDetail(Product product, int id)
        {
            OrderDetail entity = new OrderDetail();
            entity.orders_id = id;
            entity.products_id = product.id;
            entity.products_name = product.name;
            entity.products_price = Convert.ToInt64(product.price);
            entity.products_qty = product.qty;
            db.OrderDetails.Add(entity);
            db.SaveChanges();
        }
    }
}
