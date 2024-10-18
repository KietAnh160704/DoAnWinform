using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Acess.User
{
    public class UserAcess
    {
        private Model1 context = new Model1();       
        public USER GetUserByUsername(string username)
        {
            return context.USERS.FirstOrDefault(u => u.Username == username);
        }
        
    }
}
