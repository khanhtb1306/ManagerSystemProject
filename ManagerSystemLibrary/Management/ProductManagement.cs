using ManagerSystemLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSystemLibrary.Management
{
    public class ProductManagement
    {
        private static ProductManagement instance;
        private static readonly object instanceLock = new object();
        private ProductManagement() { }
        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }

            }
        }
        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                products = managerDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return products;
        }
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                var managerDB = new Management_System_ProjectContext();
                product = managerDB.Products.SingleOrDefault(product => product.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void AddNewProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    Product _product = GetProductByID(product.ProductId);
                    if (_product == null)
                    {
                        var managerDB = new Management_System_ProjectContext();
                        managerDB.Products.Add(product);
                        managerDB.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("The product is already exist");

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
