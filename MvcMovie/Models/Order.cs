using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Order
    {
        public int OrderId { get; set; }   // ✔ dùng trong View

        public DateTime OrderDate { get; set; }  // ✔ dùng trong View

        // Khóa ngoại tới Customer
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // Danh sách chi tiết đơn hàng
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}