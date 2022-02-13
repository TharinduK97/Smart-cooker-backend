using Smart_Cookers.Models;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        //public List<Image> Images { get; set; }
    }
}
