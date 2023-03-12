using System;
using System.Collections.Generic;

namespace ManagerSystemLibrary.DataAccess
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
