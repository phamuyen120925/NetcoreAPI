
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models;
public class Customer
{
    public int CustomerId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}