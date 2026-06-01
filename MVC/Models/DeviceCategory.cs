using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class DeviceCategory
    {
        [Key]
        public string CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}