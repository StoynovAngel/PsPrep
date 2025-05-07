using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Data.Sqlite;
using ShopExam.Model;

namespace ShopExam.ViewModel;

public class MainWindowVM
{
    public MainWindowVM(Item i)
    {
        if (i == null)
            i = new Item();
        else
            DisplayItem = i;

        CartList = new List<Item>();
        AddToCartCommand = new RelayCommand(AddToCart);
        GenerateReceiptCommand = new RelayCommand(ExecuteGenerateReceipt);
        CreateOrderCommand = new RelayCommand(CreateOrderButton);
    }

    public Item DisplayItem { get; set; }
    public List<Item> CartList { get; set; }
    public ICommand AddToCartCommand { get; set; }
    public ICommand GenerateReceiptCommand { get; set; }

    public ICommand CreateOrderCommand { get; set; }

    public double TotalPrice => CartList.Sum(item => item.SinglePrice);
    
    public int Quantity { get; set; } = 1;

    public void PreviewCartItem(int index)
    {
        if (index >= 0 && index < CartList.Count)
            DisplayItem = CartList[index];
    }
    
    private void AddToCart(object obj)
    {
        DiscountPrice();
        for (var i = 0; i < Quantity; i++)
        {
            CartList.Add(DisplayItem);
        }
        var sb = new StringBuilder();
        foreach (var item in CartList)
        {
            sb.AppendLine($"Име: {item.Name}");
            sb.AppendLine($"Цена: {item.SinglePrice} лв.");
            sb.AppendLine($"Инв. №: {item.InfentoryNo}");
            sb.AppendLine($"Описание: {item.Descr}");
            sb.AppendLine($"Date: {item.ExpirationDate}");
            sb.AppendLine("----------------------");
        }
        MessageBox.Show($"{Quantity} бр. от артикула добавени в количката.\n\n" + sb.ToString(), "Добавяне");
    }

    private void CreateOrderButton(object o)
    {
        MessageBox.Show(CreateOrder().ToString() + "\n" + "Was create successfully.");
    }
    
    private long CreateOrder()
    {
        try
        {
            using var context = new SmContext();
            context.Database.EnsureCreated();
            var order = new Order
            {
                Items = new List<Item>(CartList)
            };
            context.Orders.Add(order);
            context.SaveChanges();
            return order.Id;
        }
        catch (SqliteException e)
        {
            MessageBox.Show("Database Error");
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            MessageBox.Show("Unexpected error occured");
            Console.WriteLine(e);
        }

        return 0;
    }

    private void ExecuteGenerateReceipt(object obj)
    {
        var receipt = GenerateReceipt();
        MessageBox.Show(receipt, "Касов бон");
    }

    private string GenerateReceipt()
    {
        if (CartList.Count == 0)
            return "Количката е празна.";

        var sb = new StringBuilder();
        sb.AppendLine("КАСОВ БОН:");
        sb.AppendLine("----------------------");

        foreach (var item in CartList)
        {
            sb.AppendLine($"Име: {item.Name}");
            sb.AppendLine($"Цена: {item.SinglePrice} лв.");
            sb.AppendLine($"Инв. №: {item.InfentoryNo}");
            sb.AppendLine($"Описание: {item.Descr}");
            sb.AppendLine("----------------------");
        }

        return sb.ToString();
    }

    private void DiscountPrice()
    {
        var daysLeft = (DisplayItem.ExpirationDate - DateTime.Today).TotalDays;
        if (daysLeft <= 7)
        {
            DisplayItem.SinglePrice = Math.Round(DisplayItem.SinglePrice * 0.8, 2);
            MessageBox.Show("Item price discounted by 20%");
        }
    }
}