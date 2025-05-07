using System.Windows;
using ShopExam.Model;
using ShopExam.ViewModel;

namespace ShopExam.View;

public partial class MainWindow : Window
{
    private MainWindowVM vm = new(new Item
    {
        Name = "Hotdog",
        SinglePrice = 30,
        InfentoryNo = 2,
        Descr = "With mustard",
        ExpirationDate = DateTime.Today.AddDays(7)
    });

    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = vm;
    }

    private void OpenCartWindow_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowVM;
        vm?.PreviewCartItem(0);
        var cartWindow = new CartWindow();
        cartWindow.DataContext = vm;
        cartWindow.ShowDialog();
    }
}