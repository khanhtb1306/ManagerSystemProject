using System;
using System.Collections.Generic;

namespace ManagerSystemLibrary.DataAccess
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ImportPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int NumberOfInventoty { get; set; }
        public DateTime DateAdd { get; set; }
        public string? Image { get; set; }
        public string Status { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
