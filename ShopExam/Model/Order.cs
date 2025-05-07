using System.ComponentModel.DataAnnotations.Schema;

namespace ShopExam.Model;

[Table("Orders")]
public class Order
{
    public long Id { get; set; }
    public List<Item> Items { get; set; } = new();
}