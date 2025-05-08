using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Party.Model;

public class PartyContext : DbContext
{
    public DbSet<PartyRequest> Request { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=party.db");
    }
}

[Table("party_request")]
public class PartyRequest
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestId { get; set; }
    public string Applicant { get; set; }
    public string ApplicantPN { get; set; }
    public string BirthdayPerson { get; set; }
    public int BirthdayPersonAge { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime Partydate { get; set; }
    public int Baloons { get; set; }
    public int BaloonsWithHelium { get; set; }
    public List<Guest> Guests { get; set; }
}

public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int GuestAge { get; set; }
    public string GuestName { get; set; }
}

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public List<PartyRequest> PartyRequest { get; set; } = new();
    public string Status { get; set; } = "COMPLETED";
}