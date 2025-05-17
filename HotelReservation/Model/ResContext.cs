using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Model;

public class ResContext : DbContext
{
    public ResContext() : base() {}
    
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
}

public class Hotel
{
    public int Id { get; set; }
    public int Stars { get; set; }
    public string Name { get; set; }
}

public class Reservation
{
    public int Id { get; set; }
    public string ReservationPersonName { get; set; }
    public string ReservationPersonEmail { get; set; }
    public int PeopleCount { get; set; }
    public DateTime FirstDate { get; set; }
    public DateTime LastDate { get; set; }
    public RoomType RequestedType { get; set; }
    public Hotel Hotel { get; set; }
}

public enum RoomType
{
    DOUBLE,
    SUITE,
    APPARTMENT
}