using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cookers.Models
{
    public enum OrderStatus
    {
        Pending,
        Complete,
        Cancel
    }
    public class Order
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public int TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public StaffMember StaffMember { get; set; } = null;
        public Outlet Outlet { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }


    }
}
