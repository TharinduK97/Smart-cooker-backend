using System;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class AssignProdcutDto
    {

        public int AvailableQuantity { get; set; }
        public Guid OutletId { get; set; }
        public Guid ProductId { get; set; }
    }
}
