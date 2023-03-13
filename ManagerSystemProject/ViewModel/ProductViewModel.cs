using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ManagerSystemLibrary.DataAccess;
using ManagerSystemLibrary.Repository;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ManagerSystemProject.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        IProductRepository productRepository;
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectedItemChangedCommand { get; set; }
        public ICommand ImportExcel { get; set; }

        private ObservableCollection<string> _comboItems;
        public ObservableCollection<string> ComboItems
        {
            get { return _comboItems; }
            set
            {
                _comboItems = value;
                OnPropertyChanged("ComboItems");
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private IEnumerable<Product> products;
        public IEnumerable<Product> Products { get { return products; } set { products = value; OnPropertyChanged(); } }

        private Product product;
        public Product Product
        {
            get => product; set
            {
                product = value; OnPropertyChanged();
                if (product != null)
                {
                    ProductName = product.ProductName;
                    ImportPrice = product.ImportPrice;
                    SellPrice = product.SellPrice;
                    NumberOfInventoty = product.NumberOfInventoty;
                    DateAdd = DateTime.ParseExact(product.DateAdd.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    Image = product.Image;
                    Status = product.Status;
                    CategoryId = product.CategoryId;
                }
            }
        }

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

        public ProductViewModel()
        {
            ComboItems = new ObservableCollection<string>() { "ImportPrice", "SellPrice", "Number", "Best seller", "New product" };
            productRepository = new ProductRepository();
            Products = productRepository.GetProducts();
            AddCommand = new ReplayCommand<object>((p) => { return true; }, (p) =>
            {
                var product = new Product()
                {
                    ProductName = ProductName,
                    ImportPrice = ImportPrice,
                    SellPrice = SellPrice,
                    NumberOfInventoty = NumberOfInventoty,
                    DateAdd = DateAdd,
                    Image = Image,
                    Status = Status,
                    CategoryId = CategoryId
                };

                if (MessageBox.Show("Do you want insert product?", "Insert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    productRepository.InsertProduct(product);
                    Products = productRepository.GetProducts();
                }

            });
            UpdateCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (product == null)
                    {
                        return false;
                    }
                    var displayProduct = productRepository.GetProductById(Product.ProductId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },

                (p) =>
                {
                    var update = productRepository.GetProductById(Product.ProductId);

                    update.ProductName = ProductName;
                    update.ImportPrice = ImportPrice;
                    update.SellPrice = SellPrice;
                    update.NumberOfInventoty = NumberOfInventoty;
                    update.DateAdd = DateAdd;
                    update.Image = Image;
                    update.Status = Status;
                    update.CategoryId = CategoryId;
                    if (MessageBox.Show("Do you want update product?", "Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        productRepository.UpdateProduct(update);
                        Products = productRepository.GetProducts();
                    }

                });
            DeleteCommand = new ReplayCommand<object>(
                (p) =>
                {

                    if (product == null)
                    {
                        return false;
                    }
                    var displayProduct = productRepository.GetProductById(Product.ProductId);
                    if (displayProduct == null)
                    {
                        return false;
                    }
                    return true;
                },

                (p) =>
                {
                    var delete = productRepository.GetProductById(Product.ProductId);
                    if (MessageBox.Show("Do you want delete product?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        productRepository.DeleteProduct(delete);
                        Products = productRepository.GetProducts();
                    }


                });
            SelectedItemChangedCommand = new ReplayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                SelectedItem = p.SelectedValue.ToString();
                Products = productRepository.GetProductsOrderBy(SelectedItem);

            });
            ImportExcel = new ReplayCommand<Object>((p) => { return true; }, (p) =>
            {
                string fileName = "Products.xlsx";
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Products" };
                    sheets.Append(sheet);

                    // Create column headers in the worksheet
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    Row headerRow = new Row();
                    headerRow.AppendChild(CreateCell("ProductId"));
                    headerRow.AppendChild(CreateCell("ProductName"));
                    headerRow.AppendChild(CreateCell("ImportPrice"));
                    headerRow.AppendChild(CreateCell("SellPrice"));
                    headerRow.AppendChild(CreateCell("NumberOfInventoty"));
                    headerRow.AppendChild(CreateCell("DateAdd"));
                    headerRow.AppendChild(CreateCell("Image"));
                    headerRow.AppendChild(CreateCell("Status"));
                    headerRow.AppendChild(CreateCell("CategoryId"));

                    sheetData.AppendChild(headerRow);

                    // Write product data to the worksheet
                    foreach (Product product in Products)
                    {
                        Row dataRow = new Row();
                        dataRow.AppendChild(CreateCell(product.ProductId.ToString()));
                        dataRow.AppendChild(CreateCell(product.ProductName));
                        dataRow.AppendChild(CreateCell(product.ImportPrice.ToString()));
                        dataRow.AppendChild(CreateCell(product.SellPrice.ToString()));
                        dataRow.AppendChild(CreateCell(product.NumberOfInventoty.ToString()));
                        dataRow.AppendChild(CreateCell(product.DateAdd.ToString()));
                        dataRow.AppendChild(CreateCell(product.Image.ToString()));
                        dataRow.AppendChild(CreateCell(product.Status.ToString()));
                        dataRow.AppendChild(CreateCell(product.CategoryId.ToString()));


                        sheetData.AppendChild(dataRow);
                    }

                    worksheetPart.Worksheet.Save();
                }
            });

        }
        private Cell CreateCell(string value)
        {
            if(value == null)
            {
                return new Cell(new InlineString(""));

            }
            return new Cell(new InlineString(new Text(value)));
        }

    }
}
