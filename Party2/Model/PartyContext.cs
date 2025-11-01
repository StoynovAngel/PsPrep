using Microsoft.EntityFrameworkCore;

namespace Party2.Model;

public class PartyContext : DbContext
{
    public PartyContext() : base() {}

    public DbSet<PartyRequest> Request { get; set; }
    public DbSet<Guest> Guests { get; set; }
}

public class Guest
{
    public int Id { get; set; }
    public int GuestAge { get; set; }
    public string GuestName { get; set; }
}

public class PartyRequest
{
    public int RequestId { get; set; }
    public string Applicant { get; set; }
    public string ApplicantPN { get; set; }
    public string BirthdayPerson { get; set; }
    public int BirthdayPersonAge { get; set; }

    public DateTime Birthday { get; set; }
    public DateTime Partydate { get; set; }

    public int Baloons { get; set; }
    public List<Guest> Guests { get; set; }
}