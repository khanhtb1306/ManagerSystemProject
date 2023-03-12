using ManagerSystemLibrary.DataAccess;
using ManagerSystemLibrary.Repository;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagerSystemProject.ViewModel
{
    public class ProductViewModel:BaseViewModel
    {
        IProductRepository productRepository;
        public ICommand AddCommand { get; set; }
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products { get { return products; } set { products = value; OnPropertyChanged();  } }

        private Product product;
        public Product Product { get => product; set { product = value; OnPropertyChanged();
            if(product != null)
                {
                    ProductName = product.ProductName;
                    ImportPrice= product.ImportPrice;
                    SellPrice= product.SellPrice;
                    NumberOfInventoty= product.NumberOfInventoty;
                    DateAdd= DateTime.ParseExact(product.DateAdd.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    Image= product.Image;
                    Status= product.Status;
                    CategoryId= product.CategoryId;
                }
            } }

        private string productName;
        public string ProductName { get => productName; set { productName = value; OnPropertyChanged(); } }

        private decimal importPrice;
        public decimal ImportPrice { get => importPrice; set { importPrice = value; OnPropertyChanged(); } }

        private decimal sellPrice;
        public decimal SellPrice { get => sellPrice; set { sellPrice = value; OnPropertyChanged(); } }

        private int numberOfInventoty;
        public int NumberOfInventoty { get => numberOfInventoty; set { numberOfInventoty = value; OnPropertyChanged(); } }

        private DateTime dateAdd;
        public DateTime DateAdd { get => dateAdd; set { dateAdd = value; OnPropertyChanged(); } }

        private string image;
        public string? Image { get => image; set { image = value; OnPropertyChanged(); } }

        private string status;
        public string Status { get => status; set { status = value; OnPropertyChanged(); } }

        private int? categoryId;
        public int? CategoryId { get => categoryId; set { categoryId = value; OnPropertyChanged(); } }

        public ProductViewModel() { 
            productRepository= new ProductRepository();
            Products = productRepository.GetProducts();
            AddCommand = new ReplayCommand<object>((p) => { return true; }, (p) => {
               var product = new Product() { ProductName = ProductName,ImportPrice= ImportPrice,SellPrice= SellPrice,
                   NumberOfInventoty=NumberOfInventoty,DateAdd=DateAdd,Image=Image,Status=Status,CategoryId=CategoryId };
                productRepository.InsertProduct(product);
            });


        }

    }
}
