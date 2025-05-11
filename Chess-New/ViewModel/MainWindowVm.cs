using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Chess_New.Model;

namespace Chess_New.ViewModel;

public class MainWindowVm : INotifyPropertyChanged
{
    public ICommand CheckMateCommand { get; }

    public MainWindowVm(ChessGame g)
    {
        Game = g;
        CheckMateCommand = new RelayCommand(ExecuteCheckmate);
    }

    private void ExecuteCheckmate()
    {
        foreach (var move in Game.Moves)
        {
            if (move.EndPos.Contains('#'))
            {
                MessageBox.Show("Checkmate");
            }
        }
    }

    public string FormattedOutput
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            int numberToBeDisplayed = 0;
            for (var i = 0; i < Game.Moves.Count; i++)
            {
                numberToBeDisplayed = i + 1;
                sb.Append("Ход: " + numberToBeDisplayed + " от " + Game.Moves[i].StartPos + " на " + Game.Moves[i].EndPos + "\n");
            }

            return sb.ToString();
        }
    }

    public ChessGame Game { get; }

    public string P1 => GetPlayerNameById(Game.Player1);

    public string P2 => GetPlayerNameById(Game.Player2);

    public static string GetPlayerNameById(int id)
    {
        return id switch
        {
            1 => "IdoTryHard",
            2 => "TheBestzzz",
            _ => "Unknown"
        };
    }

    public string? GetBlackQueenFirstMove()
    {
        List<Move> moves = Game.Moves;
        return (from move in moves where move.StartPos == "d1" select move.EndPos).FirstOrDefault();
    }
    
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => _execute();

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
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