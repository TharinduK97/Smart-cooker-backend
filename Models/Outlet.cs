using System;

namespace Smart_Cookers.Models
{
    public class Outlet
    {
        public  Guid Id { get; set; }
        public int DoorNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
