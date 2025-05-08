using System.Windows;
using Microsoft.EntityFrameworkCore;
using Party.Model;
using Party.View;

namespace Party;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        using var context = new PartyContext();
        context.Database.Migrate();
        
    }
    
    private void OnCompleteClicked(object sender, RoutedEventArgs e)
    {
        if (DataContext is Party.ViewModel.ViewModel vm)
        {
            var gw = new GuestWindow
            {
                DataContext = vm
            };
            gw.Show();
            Close();
        }
    }

}