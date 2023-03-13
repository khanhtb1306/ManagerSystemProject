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
        public void DeleteProduct(Product product) => ProductManagement.Instance.DeleteProduct(product);

        public Product GetProductById(int id) => ProductManagement.Instance.GetProductByID(id);

        public IEnumerable<Product> GetProducts() => ProductManagement.Instance.GetProductList();

        public IEnumerable<Product> GetProductsOrderBy(string property) => ProductManagement.Instance.GetProductsOrderBy(property);



        public void InsertProduct(Product product) => ProductManagement.Instance.AddNewProduct(product);

        public void UpdateProduct(Product product) => ProductManagement.Instance.UpdateProduct(product);
        
    }
}
