using System.ComponentModel;
using System.Runtime.CompilerServices;
using Election.Model;

namespace Election.ViewModel;

public class VotingViewModel : INotifyPropertyChanged
{
    private VotingResult _votingResult;
    
    private List<Vote> _allVotes;

    public VotingViewModel(VotingResult votingResult, List<Vote> votes)
    {
        _votingResult = votingResult;
        _allVotes = votes;
        RefreshResult();
    }
    
    public int ForVotes => _allVotes.Count(v => v.VoteTypeEnum == VoteType.FOR);
    public int AgainstVotes => _allVotes.Count(v => v.VoteTypeEnum == VoteType.AGAINST);
    public int AbstainVotes => _allVotes.Count(v => v.VoteTypeEnum == VoteType.ABSTAIN);
    
    public DateTime Deadline => _votingResult.Date;

    private void RefreshResult()
    {
        OnPropertyChanged(nameof(ForVotes));
        OnPropertyChanged(nameof(AgainstVotes));
        OnPropertyChanged(nameof(AbstainVotes));
    }
    
    private void SaveToDatabase(List<Vote> votes)
    {
        using var context = new VotingContext();
        foreach (var vote in votes)
        {
            context.Votes.Add(vote);
        }
        context.SaveChanges();
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