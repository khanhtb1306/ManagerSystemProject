using System;
using System.Collections.Generic;

namespace ManagerSystemLibrary.DataAccess
{
    public partial class ProductBill
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
