using System;

namespace Smart_Cookers.Dtos.OutletDtos
{
    public class GetOutletOrderDto
    {
        public Guid Id { get; set; }
        public int DoorNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
