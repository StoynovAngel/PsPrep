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
using Football.Model;
using Football.ViewModel;

namespace Football;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FootballMatch footballMatch = new FootballMatch
        {
            ForeignTeam = "Barcelona",
            HomeTeam = "Real Madrid",
            ScoreForeign = 3,
            ScoreHome = 4,
            Start = DateTime.Today
        };
        
        FootballMatch match1 = new FootballMatch
        {
            ForeignTeam = "Barcelona",
            HomeTeam = "Real Madrid",
            ScoreForeign = 1,
            ScoreHome = 2,
            Start = DateTime.Today.AddDays(-7)
        };

        FootballMatch match2 = new FootballMatch
        {
            ForeignTeam = "Barcelona",
            HomeTeam = "Real Madrid",
            ScoreForeign = 2,
            ScoreHome = 2,
            Start = DateTime.Today.AddDays(-30)
        };
        
        var vm = new MainWindowVM(footballMatch);
        vm.AllMatches.Add(footballMatch);
        vm.AllMatches.Add(match1);
        vm.AllMatches.Add(match2);
        DataContext = vm;
    }
}