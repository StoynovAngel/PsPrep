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
using HotelReservation.Model;

namespace HotelReservation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Hotel hotel = new Hotel
        {
            Id = 1,
            Name = "Trivago",
            Stars = 5
        };

        Reservation r = new Reservation
        {
            Id = 1,
            FirstDate = DateTime.Today,
            LastDate = DateTime.Today.AddDays(7),
            Hotel = hotel,
            PeopleCount = 10,
            RequestedType = RoomType.APPARTMENT,
            ReservationPersonName = "Angel",
            ReservationPersonEmail = "angelstoinov12@gmail.com"
        };
        var vm = new ViewModel.ViewModel(r);
        DataContext = vm;
        
    }
}