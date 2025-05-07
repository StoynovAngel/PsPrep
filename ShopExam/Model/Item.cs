using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopExam.Model;

[Keyless]
[NotMapped]
public class Item
{
    public string Name { get; set; }
    public double SinglePrice { get; set; }
    public long InfentoryNo { get; set; }
    public string Descr { get; set; }
    public byte[] Image { get; set; }

    public DateTime ExpirationDate { get; set; } = DateTime.Today.AddDays(7);

}