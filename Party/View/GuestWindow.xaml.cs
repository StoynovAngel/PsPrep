using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Party.Model;

namespace Party.View;

public partial class GuestWindow : Window
{
    
    public int SelectedGuestId { get; set; }

    public GuestWindow()
    {
        InitializeComponent();
        if (DataContext is Party.ViewModel.ViewModel vm)
        {
            GuestIdComboBox.ItemsSource = vm.Request.Guests;
        }
    }

    private void DeleteOnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is Party.ViewModel.ViewModel vm)
        {
            vm.DeleteById(SelectedGuestId);
            GuestIdComboBox.ItemsSource = null;
            GuestIdComboBox.ItemsSource = vm.Request.Guests;
        }
    }

    private void GuestIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (GuestIdComboBox.SelectedValue is int id)
        {
            SelectedGuestId = id;
        }
    }

    private void ApproveRequest_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is Party.ViewModel.ViewModel vm)
        {
            using var context = new PartyContext();

            var attachedRequest = context.Request
                .Include(r => r.Guests)
                .FirstOrDefault(r => r.RequestId == vm.Request.RequestId);

            if (attachedRequest == null)
            {
                MessageBox.Show("Заявката не е записана предварително.");
                return;
            }

            var order = new Order
            {
                PartyRequest = new List<PartyRequest> { attachedRequest },
                Status = "APPROVED"
            };

            context.Orders.Add(order);
            context.SaveChanges();

            MessageBox.Show("Заявката беше одобрена успешно.");
        }
    }
}