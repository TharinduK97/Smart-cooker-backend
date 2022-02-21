using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.OrderDtos
{
    public class GetOrderProductsDto
    {
        public int Quantity { get; set; }

        public GetProductDto Product { get; set; }

    }
}
