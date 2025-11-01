using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Party2.Model;

namespace Party2.ViewModel;

public class ViewModelClass : INotifyPropertyChanged
{
    private PartyRequest pr;
    public PartyRequest Request
    {
        get => pr;
        set
        {
            pr = value;
            OnPropertyChanged(nameof(Request));
        }
    }

    public string CaptionName { get; set; } = "Име на рожденника ";
    public string CaptionAge { get; set; } = "Години на рожденника ";
    public string CaptionDate { get; set; } = "Дата на раждане на рожденника ";

    public ICommand AddCommand { get; set; }
    
    public ObservableCollection<PartyRequest> Requests { get; set; }


    public ViewModelClass()
    {
        AddCommand = new AddRequestCommand();
        Request = new PartyRequest
        {
            RequestId = 1,
            Applicant = "Ангел Стоянов",
            ApplicantPN = "0888123456",
            BirthdayPerson = "Георги Иванов",
            BirthdayPersonAge = 10,
            Birthday = new DateTime(2014, 5, 10),
            Partydate = DateTime.Now.AddDays(7),
            Baloons = 20,
            Guests = new List<Guest>
            {
                new Guest { Id = 1, GuestName = "Иван Петров", GuestAge = 11 },
                new Guest { Id = 2, GuestName = "Мария Георгиева", GuestAge = 10 }
            }
        };

        // Инициализирай колекцията с един запис
        Requests = new ObservableCollection<PartyRequest>
        {
            Request
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

public class AddRequestCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return parameter is ViewModelClass;
    }

    public void Execute(object parameter)
    {
        if (parameter is ViewModelClass vm)
        {
            try
            {
                using (var context = new PartyContext())
                {
                    context.Request.Add(vm.Request);
                    context.SaveChanges();
                }

                Debug.WriteLine("Успешно добавена заявка.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Грешка при запис в базата: " + ex.Message);
            }
        }
    }
}