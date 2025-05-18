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
using Flowers.Model;
using Flowers.View;
using Flowers.ViewModel;

namespace Flowers;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FlowerDelivery f = new FlowerDelivery
        {
            Id = 1,
            Address = "Pz",
            Delivered = false,
            Phone = "0890504411",
            DeliveryDate = DateTime.Now.AddDays(1),
            Flowers = [
                new Flower
                {
                    Count = 10,
                    Id = 1,
                    FlowerType = "Rose"
                },
                new Flower
                {
                Count = 5,
                Id = 2,
                FlowerType = "Tulip"
                }
            ]
        };
        DataContext = new DeliveryViewModel(f);
        FlowerWindow flowerWindow = new FlowerWindow();
        flowerWindow.Show();
    }
}