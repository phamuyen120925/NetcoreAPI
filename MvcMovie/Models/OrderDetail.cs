using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models;
public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }

    public decimal Price { get; set; }
}