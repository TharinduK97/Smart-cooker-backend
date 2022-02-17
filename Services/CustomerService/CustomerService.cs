using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.AddressDtos;
using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetAddressDto>>> AddAddress(AddAddressDto newAddress)
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var serviceResponse = new ServiceResponse<List<GetAddressDto>>();
            Address address = _mapper.Map<Address>(newAddress);
            address.Customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id == Guid.Parse(UserId));
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Addresses
                .Where(c => c.Customer.Id == Guid.Parse(UserId))
                .Select(c => _mapper.Map<GetAddressDto>(c)).ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCustomerDto>> GetCustomerById()
        {
             var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var serviceResponse = new ServiceResponse<GetCustomerDto>();
            var dbCustomer = await _context.Customers
                  .Include(p => p.Addresses)
                 .FirstOrDefaultAsync(c => c.Id == Guid.Parse(UserId));

            serviceResponse.Data = _mapper.Map<GetCustomerDto>(dbCustomer);
            return serviceResponse;
        }
    }
}
