using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Election.Model;

public class VotingContext : DbContext
{
    public VotingContext() : base() {}
    public DbSet<VotingResult> VotingResults { get; set; }
    public DbSet<Vote> Votes { get; set; }
}

public class VotingResult
{
    public int Id { get; set; }
    public int ForVotes { get; set; }
    public int AgainstVotes { get; set; }
    public int AbstainedVotes { get; set; }
    public DateTime Date { get; set; }
}

public class Vote
{
    public int Id { get; set; }
    public VoteType VoteTypeEnum { get; set; }
    public DateTime VoteDate { get; set; }
}

public enum VoteType
{
    AGAINST,
    FOR,
    ABSTAIN
}