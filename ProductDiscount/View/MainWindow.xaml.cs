using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductDiscount.Model;
using ProductDiscount.ViewModel;

namespace ProductDiscount;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Product product1 = new Product
        {
            Disc = new Discount
            {
                DiscountId = 1,
                DiscountPerc = 10.25f,
                ProductId = 1,
                ValidUntil = DateTime.Now.AddMonths(3)
            },
            Name = "Eggs",
            ProductId = 1,
            RegularPrice = 20,
            Type = "Dairy Product"
        };
        Product product2 = new Product
        {
            Disc = new Discount
            {
                DiscountId = 1,
                DiscountPerc = 10.25f,
                ProductId = 1,
                ValidUntil = DateTime.Now.AddDays(1)
            },
            Name = "Bacon",
            ProductId = 1,
            RegularPrice = 20,
            Type = "Dairy Product"
        };
        var vm = new MainWindowVM(product1);
        vm.Products.Add(product1);
        vm.Products.Add(product2);
        DataContext = vm;
    }
}