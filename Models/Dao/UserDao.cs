using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class UserDao
    {
        SieuThiOnline db = null;

        public UserDao()
        {
            db = new SieuThiOnline();
        }
        public int Insert(User entity)
        {
            var userExixt = db.Users.Any(x => x.username == entity.username); //kiểm tra xem đã tồn tại tài khoản này chưa  
            if (userExixt)
            {
                return 0;
            }else{
                entity.created_at = DateTime.Now;
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.id;
            }
            
        }

        public User getUserByUsername(string userName)
        {
            return db.Users.SingleOrDefault(x => x.username == userName);
        }
        public bool login(string name, string password)
        {
            var result = db.Users.Count(x => x.username == name && x.password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
