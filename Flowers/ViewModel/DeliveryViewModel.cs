using System.Collections.ObjectModel;
using System.Windows.Input;
using Flowers.Model;
using Flowers.View;

namespace Flowers.ViewModel;

public class DeliveryViewModel
{
    private FlowerDelivery _flower;
    public string Amount => Helper.Extension(_flower).ToString();

    public FlowerDelivery FlowerDelivery
    {
        get => _flower;
        set
        {
            _flower = value;
        }
    }
    
    public ICommand Delivered { get; set; }

    public DeliveryViewModel(FlowerDelivery fd)
    {
        _flower = fd;
        Delivered = new DeliveredCommand();
    }
}

public class DeliveredCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        if (parameter is FlowerDelivery delivery)
            return !delivery.Delivered;

        return false;
    }

    public void Execute(object parameter)
    {
        if (parameter is FlowerDelivery delivery)
        {
            delivery.Delivered = true;
        }
    }
}

public static class Helper
{
    public static int Extension(FlowerDelivery flowerDelivery)
    {
        return flowerDelivery.Flowers.Sum(flower => flower.Count);
    }
}