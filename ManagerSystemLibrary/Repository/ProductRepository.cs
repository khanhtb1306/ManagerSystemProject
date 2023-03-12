using ManagerSystemLibrary.DataAccess;
using ManagerSystemLibrary.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystemLibrary.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductManagement.Instance.GetProductList();

        public void InsertProduct(Product product) => ProductManagement.Instance.AddNewProduct(product);
    }
}
