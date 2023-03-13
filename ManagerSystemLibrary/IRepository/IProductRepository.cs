using ManagerSystemLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystemLibrary.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> GetProductsOrderBy(string property);
       

    }
}
