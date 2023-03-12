using ManagerSystemLibrary.DataAccess;
using ManagerSystemLibrary.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystemLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByName(string userName) => UserManagement.Instance.GetUserByUserName(userName);
        
    }
}
