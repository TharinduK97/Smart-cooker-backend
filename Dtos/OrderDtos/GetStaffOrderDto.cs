using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.OrderDtos
{
    public class GetStaffOrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public Outlet Outlet { get; set; }
        public ICollection<Product> Products { get; set; }
       
    }
}
