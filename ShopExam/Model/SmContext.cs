using Microsoft.EntityFrameworkCore;

namespace ShopExam.Model;

public class SmContext : DbContext
{
    public SmContext() : base() {}

    public DbSet<Person> People { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=shop.db");
    }
}

[Keyless]
public class Person
{
    public Person(string Name)
    {
        this.Name = Name;
    }

    public string Name { get; set; }
}