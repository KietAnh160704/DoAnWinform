using DAL.Acess.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.User
{
    public class UserService
    {
        private UserAcess userAccess;

        public UserService()
        {
            userAccess = new UserAcess();
        }

        public bool Login(string username, string password)
        {
            var user = userAccess.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
