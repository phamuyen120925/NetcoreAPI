using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class ImportDetail
    {
        [Key]
        public int Id { get; set; }

        public string ImportID { get; set; }

        public string DeviceID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount
        {
            get { return Quantity * UnitPrice; }
        }

        [ForeignKey("ImportID")]
        public ImportReceipt? ImportReceipt { get; set; }

        [ForeignKey("DeviceID")]
        public Device? Device { get; set; }
    }
}