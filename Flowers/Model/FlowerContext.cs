using Microsoft.EntityFrameworkCore;

namespace Flowers.Model;

public class FlowerContext : DbContext
{
    public FlowerContext() : base() {}
    public DbSet<FlowerDelivery> FlowerDeliveries { get; set; }
    public DbSet<Flower> Flowers { get; set; }
}
public class FlowerDelivery
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<Flower> Flowers { get; set; }
    public bool Delivered { get; set; }
}

public class Flower
{
    public int Id { get; set; }
    public string FlowerType { get; set; }
    public int Count { get; set; }
}