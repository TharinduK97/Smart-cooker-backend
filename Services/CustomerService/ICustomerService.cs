using Smart_Cookers.Dtos.AddressDtos;
using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<GetCustomerDto>> GetCustomerById();
        Task<ServiceResponse<List<GetAddressDto>>> AddAddress(AddAddressDto newAddress);
    }
}
