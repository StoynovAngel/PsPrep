using System.Windows;
using Chess_New.Model;
using Chess_New.View;
using Chess_New.ViewModel;

namespace Chess_New;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var game = new ChessGame
        {
            Id = 34551324,
            Player1 = 1,
            Player2 = 2,
            P1Color = 'B',
            Start = new DateTime(2023, 6, 12, 9, 45, 0),
            Moves =
            [
                new Move
                {
                    Id = 1,
                    MoveTime = new DateTime(2023, 6, 12, 9, 50, 0),
                    StartPos = "e2",
                    EndPos = "e4"
                },

                new Move
                {
                    Id = 2,
                    MoveTime = new DateTime(2023, 6, 12, 9, 52, 0),
                    StartPos = "d1",
                    EndPos = "d5"
                }
            ],
            TimeLimit = 120
        };

        var vm = new MainWindowVm(game);
        DataContext = vm;

        var movesWindow = new ChessMovesWindow(vm);
        movesWindow.ShowDialog();
    }
}