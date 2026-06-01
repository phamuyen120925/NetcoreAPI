using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Device
    {
        [Key]
        public string DeviceID { get; set; }

        [Required]
        public string DeviceName { get; set; }

        public string SupplierID { get; set; }

        public string CategoryID { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }

        [ForeignKey("CategoryID")]
        public DeviceCategory? DeviceCategory { get; set; }
    }
}