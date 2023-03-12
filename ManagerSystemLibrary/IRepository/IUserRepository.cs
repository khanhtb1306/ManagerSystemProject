using ManagerSystemLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystemLibrary.Repository
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
    }
}
