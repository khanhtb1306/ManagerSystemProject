using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerSystemLibrary.DataAccess;

namespace ManagerSystemLibrary.Management
{
    public class UserManagement
    {
        private static UserManagement instance;
        private static readonly object instanceLock = new object();
        private UserManagement() { }
        public static UserManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserManagement();
                    }
                    return instance;
                }

            }
        }
        public User GetUserByUserName(string userName)
        {
            User user = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                user = managerDB.Users.SingleOrDefault(user => user.UserName.Equals(userName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
