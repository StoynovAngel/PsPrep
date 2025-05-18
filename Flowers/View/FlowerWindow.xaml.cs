using System.Windows;
using Flowers.Model;
using Flowers.ViewModel;

namespace Flowers.View;

public partial class FlowerWindow : Window
{
    public FlowerWindow()
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
    }
}