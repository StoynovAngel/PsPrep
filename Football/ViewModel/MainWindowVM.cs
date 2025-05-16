using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Football.Model;

namespace Football.ViewModel;

public class MainWindowVM : INotifyPropertyChanged
{
    private FootballMatch _match;
    public List<FootballMatch> AllMatches { get; set; } = new List<FootballMatch>();
    public string WinnerStatus => WhoIsWinning();

    public FootballMatch DisplayMatch
    {
        get { return _match; }
        set
        {
            _match = value;
            OnPropertyChanged(nameof(DisplayMatch));
            OnPropertyChanged(nameof(WinnerStatus));
        }

    }

    public ICommand StoreCommand { get; set; }
    public ICommand WinCountCommand { get; set; }


public MainWindowVM(FootballMatch i)
    {
        DisplayMatch = i;
        StoreCommand = new ACommand(StoreResult);
        WinCountCommand = new ACommand(ExecuteWinCount);
    }

    private void StoreResult(object obj)
    {
        System.Diagnostics.Debug.WriteLine($"Stored match: {DisplayMatch.HomeTeam} vs {DisplayMatch.ForeignTeam}");
    }

    public string WhoIsWinning()
    {
        return (_match.ScoreHome > _match.ScoreForeign)
            ? $"{_match.HomeTeam} is winning"
            : $"{_match.ForeignTeam} is winning";
    }
    
    private void ExecuteWinCount(object obj)
    {
        string home = DisplayMatch.HomeTeam;
        string away = DisplayMatch.ForeignTeam;

        if (AllMatches == null)
        {
            MessageBox.Show("No match data available.");
            return;
        }

        NumberOfWins(home, away, AllMatches);
    }

    private void NumberOfWins(string home, string away, List<FootballMatch> matches)
    {
        int homeWinCount = 0;
        int awayWinCount = 0;
        foreach (var match in matches)
        {
            if (match.HomeTeam.Equals(home) && match.ForeignTeam.Equals(away))
            {
                if (match.ScoreHome > match.ScoreForeign)
                {
                    homeWinCount++;
                } 
                else if (match.ScoreHome < match.ScoreForeign)
                {
                    awayWinCount++;
                }
            }
        }
        MessageBox.Show($"Home team: {home} has won: {homeWinCount}\n Away team: {away} has won: {awayWinCount}");
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

public class ACommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public ACommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter!);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter!);
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}