using Smart_Cookers.Dtos.ProductDtos;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.OutletDtos
{
    public class GetOutletDto
    {
        public Guid Id { get; set; }
        public int DoorNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<GetProductDto> Products { get; set; }
    }
}
