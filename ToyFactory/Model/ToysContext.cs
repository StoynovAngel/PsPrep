using Microsoft.EntityFrameworkCore;

namespace ToyFactory.Model;

public class ToysContext : DbContext
{
    public ToysContext() : base() {}
    public DbSet<MusicalToy> MusicalToys { get; set; }
    public DbSet<ToyMelody> ToyMelodies { get; set; }
}

public class MusicalToy
{
    public int Id { get; set; }
    public string Caption { get; set; }
    public string Manufacturer { get; set; }
    public int AgeInMonths { get; set; }
    public List<ToyMelody> Melodies { get; set; }
    public Dictionary<string, ToyMelody> MelodiesByName =>
        Melodies?.ToDictionary(m => m.Name) ?? new Dictionary<string, ToyMelody>();
}

public class ToyMelody
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Composer { get; set; }
}