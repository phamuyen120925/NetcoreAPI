using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ExportReceipt
    {
        [Key]
        public string ExportID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExportDate { get; set; }

        public ICollection<ExportDetail>? ExportDetails { get; set; }
    }
}