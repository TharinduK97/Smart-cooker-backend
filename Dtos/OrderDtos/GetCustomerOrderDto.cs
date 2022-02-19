using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.OrderDtos
{
    public class GetCustomerOrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int TotalPrice { get; set; }
        public GetOutletOrderDto Outlet { get; set; }

        //public ICollection<Product> Products { get; set; }
        
    }
}
