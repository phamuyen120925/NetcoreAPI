using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models;
public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Range(0, 100000000)]
    public decimal Price { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}