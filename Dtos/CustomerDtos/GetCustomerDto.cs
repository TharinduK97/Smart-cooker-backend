using Smart_Cookers.Models;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.CustomerDtos
{
    public class GetCustomerDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nic { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
