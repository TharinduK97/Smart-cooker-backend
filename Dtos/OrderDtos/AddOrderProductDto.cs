using System;

namespace Smart_Cookers.Dtos.OrderDtos
{
    public class AddOrderProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
