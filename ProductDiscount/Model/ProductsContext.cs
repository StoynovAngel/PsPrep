using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace ProductDiscount.Model;

public class ProductsContext : DbContext
{
    public ProductsContext() : base() { }
    public DbSet<Product> Products {get;set;}
    public DbSet<Discount> Discounts {get;set;}
}
public class Product
{
    public int ProductId {get;set;}
    public string Name {get;set;}
    public string Type {get;set;}
    public decimal RegularPrice {get;set;}
    public Discount Disc {get;set;}

    public override string ToString()
    {
        return Name + ", " + Type + ", " + RegularPrice;
    }
    public Brush BackgroundColor
    {
        get
        {
            if (Disc == null) return Brushes.Gray;
            var daysLeft = Disc.ValidUntil - DateTime.Now;
            if (daysLeft.TotalDays <= 0)
                return Brushes.IndianRed;
            if (daysLeft.TotalDays <= 7)
                return Brushes.Red;
            if (daysLeft.TotalDays <= 14)
                return Brushes.DarkRed;
            return Brushes.LightGreen;
        }
    }
}
public class Discount
{
    public int DiscountId {get;set;}
    public int ProductId {get;set;}
    public float DiscountPerc {get;set;}
    public DateTime ValidUntil {get; set;}
    
} 