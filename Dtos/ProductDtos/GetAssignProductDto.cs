using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.ProductDtos
{
    public class GetAssignProductDto
    {
        //public Guid Id { get; set; }
        
        public List<GetOutletProductDto> OutletProducts { get; set; }
    }
}
