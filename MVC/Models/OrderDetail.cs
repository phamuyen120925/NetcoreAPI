using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public string OrderID { get; set; }

        public string ProductID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public Order? Order { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }
}