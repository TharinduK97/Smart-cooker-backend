using Smart_Cookers.Dtos.ImageDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string imageUrl { get; set; }
    }
}
