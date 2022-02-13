using Smart_Cookers.Models;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class AddProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

    }
}
