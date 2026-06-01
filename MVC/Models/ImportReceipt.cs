using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ImportReceipt
    {
        [Key]
        public string ImportID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ImportDate { get; set; }

        public ICollection<ImportDetail>? ImportDetails { get; set; }
    }
}