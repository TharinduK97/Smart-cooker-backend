using Smart_Cookers.Dtos.AddressDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;

namespace Smart_Cookers.Dtos.CustomerDtos
{
    public class GetCustomerDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nic { get; set; }
        public List<GetAddressDto> Addresses { get; set; }
    }
}
