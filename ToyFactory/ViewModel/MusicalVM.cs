using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ToyFactory.Model;

namespace ToyFactory.ViewModel;

public class MusicalVM : INotifyPropertyChanged
{
    private MusicalToy _musicalToy;

    public MusicalToy MusicalToy
    {
        get => _musicalToy;
        set => SetField(ref _musicalToy, value);
    }
    
    public string SearchText { get; set; }
    public ICommand GetNextCommand { get; set; }

    private List<MusicalToy> _mockToys;

    public MusicalVM()
    {
        _mockToys = new List<MusicalToy>
        {
            new MusicalToy
            {
                Id = 1,
                Caption = "Toy Piano",
                Manufacturer = "ToyCo",
                AgeInMonths = 12,
                Melodies = new List<ToyMelody>
                {
                    new ToyMelody { Id = 1, Name = "Twinkle", Genre = "Lullaby", Composer = "Unknown" }
                }
            },
            new MusicalToy
            {
                Id = 2,
                Caption = "Xylophone",
                Manufacturer = "KidsMusic",
                AgeInMonths = 24,
                Melodies = new List<ToyMelody>
                {
                    new ToyMelody { Id = 2, Name = "Happy Tune", Genre = "Kids", Composer = "Mozart" }
                }
            }
        };

        GetNextCommand = new GetNextCommand(this);
    }

    public List<MusicalToy> GetMockToys() => _mockToys;
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

public class GetNextCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private MusicalVM _viewModel;

    public GetNextCommand(MusicalVM viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        var toy = _viewModel.GetMockToys()
            .FirstOrDefault(t => t.Caption.Equals(_viewModel.SearchText, StringComparison.OrdinalIgnoreCase));

        _viewModel.MusicalToy = toy;
    }
}