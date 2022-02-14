using System;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetAssignProductDto
    {
        public int AvailableQuantity { get; set; }
        public Guid OutletId { get; set; }
        public Guid ProductId { get; set; }
    }
}
