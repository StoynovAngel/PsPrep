using System.Windows;
using System.Windows.Input;
using Party.Model;

namespace Party.ViewModel;

public class ViewModel
{
    public ViewModel()
    {
        Request = new PartyRequest
        {
            Birthday = DateTime.Today,
            Partydate = DateTime.Today.AddDays(7),
            Guests = new List<Guest>
            {
                new() { GuestName = "Мария", GuestAge = 10 },
                new() { GuestName = "Иван", GuestAge = 11 }
            }
        };
        AddCommand = new AddRequestCommand();
    }

    public PartyRequest Request { get; set; }

    public string CaptionName { get; set; } = "Име на рожденика";
    public string CaptionAge { get; set; } = "Години на рожденика";
    public string CaptionDate { get; set; } = "Дата на раждане на рожденика";

    public ICommand AddCommand { get; set; }
    
    public void DeleteById(int id)
    {
        var guest = Request.Guests.FirstOrDefault(g => g.Id == id);
        if (guest != null)
        {
            Request.Guests.Remove(guest);
            MessageBox.Show("Successfully removed this guest: " + guest.GuestName);
        }
    }
    
    public class AddRequestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                if (parameter is PartyRequest request)
                {
                    using var context = new PartyContext();
                    Helper.UpdateNumberOfHeliumBalloons(request);
                    context.Request.Add(request);
                    context.SaveChanges();
                    MessageBox.Show("Added successfully");
                }
                else
                {
                    MessageBox.Show("Invalid request object.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving.");
                Console.WriteLine(ex);
                Environment.Exit(1);
            }
        }
    }

    private static class Helper
    {
        public static void UpdateNumberOfHeliumBalloons(PartyRequest partyRequest)
        {
            int helium = (int)Math.Floor(partyRequest.Baloons / 2.0);
            int remaining = partyRequest.Baloons - helium;
           
            partyRequest.BaloonsWithHelium = helium;
            partyRequest.Baloons = remaining;
        }
    }
}