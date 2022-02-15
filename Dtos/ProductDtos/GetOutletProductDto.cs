using Smart_Cookers.Models;
using System;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetOutletProductDto
    {
        public int AvailableQuantity { get; set; }
        public Guid ProductId { get; set; }
        public GetProductDto Product { get; set; }
    }
}
