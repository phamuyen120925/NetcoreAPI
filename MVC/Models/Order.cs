using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}