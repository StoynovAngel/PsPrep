using Microsoft.EntityFrameworkCore;

namespace Football.Model;

public class MatchesContext : DbContext
{
    public MatchesContext() : base() {}
    public DbSet<FootballMatch> Matches { get; set; }
}

public class FootballMatch
{
    public string HomeTeam { get; set; }
    public string ForeignTeam { get; set; }
    public DateTime Start { get; set; }
    public int ScoreHome { get; set; }
    public int ScoreForeign { get; set; }
}