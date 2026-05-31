using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}