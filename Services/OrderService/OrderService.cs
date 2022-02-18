using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.OrderDtos;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OrderService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;

        }
        
        public async Task<ServiceResponse<List<GetCustomerOrderDto>>> AddNewOrder(AddOrderDto newOrder)
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var serviceResponse = new ServiceResponse<List<GetCustomerOrderDto>>();

            Order order = _mapper.Map<Order>(newOrder);
           // outletProduct.Product = await _context.Products.FirstOrDefaultAsync(u => u.Id == newProduct.ProductId);
            //outletProduct.Outlet = await _context.Outlets.FirstOrDefaultAsync(u => u.Id == newProduct.OutletId);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.OutletProducts
                  .Select(c => _mapper.Map<GetCustomerOrderDto>(c)).ToListAsync();
            return serviceResponse;
        }
    }
}
