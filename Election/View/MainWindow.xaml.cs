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
using Election.Model;
using Election.ViewModel;

namespace Election;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var votingResult = new VotingResult
        {
            Id = 1,
            Date = DateTime.Today.AddDays(1)
        };

        var votes = new List<Vote>
        {
            new Vote { Id = 1, VoteTypeEnum = VoteType.FOR, VoteDate = DateTime.Now },
            new Vote { Id = 2, VoteTypeEnum = VoteType.AGAINST, VoteDate = DateTime.Now },
            new Vote { Id = 3, VoteTypeEnum = VoteType.ABSTAIN, VoteDate = DateTime.Now },
            new Vote { Id = 4, VoteTypeEnum = VoteType.ABSTAIN, VoteDate = DateTime.Now },
            new Vote { Id = 5, VoteTypeEnum = VoteType.ABSTAIN, VoteDate = DateTime.Now }
        };

        DataContext = new VotingViewModel(votingResult, votes);
    }
}