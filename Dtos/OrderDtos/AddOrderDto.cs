using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.OrderDtos
{
    public class AddOrderDto
    {
      
        public int TotalPrice { get; set; }
        public Guid OutletId { get; set; }
        public List<AddOrderProductDto> Productlist { get; set; }

    }
}
