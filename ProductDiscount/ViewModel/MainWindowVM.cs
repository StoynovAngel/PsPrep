using System.Windows.Media;
using ProductDiscount.Model;

namespace ProductDiscount.ViewModel;

public class MainWindowVM
{
    public string SearchQuery { get; set;}
    public List<Product> Products { get; set; } = new List<Product>();


    private Product _selectedProduct;
    public Product SelectedP
    {
        get => _selectedProduct;
        set => _selectedProduct = value;
    }
    public MainWindowVM(Product selectedP)
    {
        SelectedP = selectedP; // selectedP instead of selectedProduct
        Products = new List<Product>();
    }

    public string Paco => DisplayProducts();
    private string DisplayProducts()
    {
        TimeSpan daysLeft = _selectedProduct.Disc.ValidUntil - DateTime.Now;
        if (daysLeft < TimeSpan.Zero) return "Not valid";
        return $"Остават: {daysLeft.Days} дни, часа: {daysLeft.Hours}";
    }
}