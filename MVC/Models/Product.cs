using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}