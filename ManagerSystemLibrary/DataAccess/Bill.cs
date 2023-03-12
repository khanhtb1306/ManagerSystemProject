using System;
using System.Collections.Generic;

namespace ManagerSystemLibrary.DataAccess
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime DateTrading { get; set; }
        public string Status { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
