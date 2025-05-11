using System.Windows;
using Chess_New.ViewModel;

namespace Chess_New.View;

public partial class ChessMovesWindow : Window
{
    public ChessMovesWindow(MainWindowVm vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}