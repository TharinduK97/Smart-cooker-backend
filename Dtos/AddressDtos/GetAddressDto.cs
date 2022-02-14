using System;

namespace Smart_Cookers.Dtos.AddressDtos
{
    public class GetAddressDto
    {
        public Guid Id { get; set; }

        public string DoorNumber { get; set; }
      
        public string Street { get; set; } 

        public string City { get; set; }
    }
}
