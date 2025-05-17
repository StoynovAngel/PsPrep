using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HotelReservation.Model;

namespace HotelReservation.ViewModel;

public class ViewModel : INotifyPropertyChanged
{
    private Reservation _res;

    public Reservation Reservation
    {
        get => _res;
        set
        {
            _res = value;
            OnPropertyChanged(nameof(Reservation));
        }
    }
    
    public string RoomText { get; set; }
    public ICommand UpdateCommand { get; }

    public ViewModel(Reservation r)
    {
        _res = r;
        RoomText = r.RequestedType.ToString();
        UpdateCommand = new RelayCommand(UpdateReservation);
    }

    private void UpdateReservation(object obj)
    {
        Reservation = new Reservation
        {
            ReservationPersonName = "Ангел",
            ReservationPersonEmail = "angel@example.com",
            PeopleCount = 2,
            FirstDate = DateTime.Today,
            LastDate = DateTime.Today.AddDays(3),
            RequestedType = RoomType.SUITE,
            Hotel = new Hotel { Name = "Hilton", Stars = 5 }
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    
}

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;

    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}