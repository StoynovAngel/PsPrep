using Microsoft.EntityFrameworkCore;

namespace Chess_New.Model;

public class ChessCtx : DbContext
{
    public DbSet<ChessGame> ChessGames { get; set; }
    public DbSet<Move> Moves { get; set; }
}

public class ChessGame
{
    public int Id { get; set; }
    public int Player1 { get; set; }
    public int Player2 { get; set; }
    public char P1Color { get; set; }
    public DateTime Start { get; set; }
    public int TimeLimit { get; set; }
    public List<Move> Moves { get; set; }
}

public class Move
{
    public int Id { get; set; }
    public DateTime MoveTime { get; set; }
    
    public TimeSpan  Increment { get; set; }
    
    public DateTime RemainingTime { get; set; }

    public string StartPos { get; set; }
    public string EndPos { get; set; }
}