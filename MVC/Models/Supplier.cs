using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Supplier
    {
        [Key]
        public string SupplierID { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public string Address { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}