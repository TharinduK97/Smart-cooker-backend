using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.OrderDtos;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using System;
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
            order.Outlet = await _context.Outlets.FirstOrDefaultAsync(u => u.Id == newOrder.OutletId);
            order.Customer= await _context.Customers.FirstOrDefaultAsync(u => u.Id == Guid.Parse(UserId));

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach(var productOrder in newOrder.Productlist)
            {
                OrderProduct orderProduct = _mapper.Map<OrderProduct>(productOrder);
                orderProduct.Order = order;
                _context.OrderProducts.Add(orderProduct);
               
                    OutletProduct outletProduct = await _context.OutletProducts
                .Include(c => c.Outlet)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Outlet.Id == newOrder.OutletId && c.Product.Id == productOrder.ProductId);
                outletProduct.AvailableQuantity = outletProduct.AvailableQuantity - productOrder.Quantity;
                await _context.SaveChangesAsync();

            }
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Orders
                  .Select(c => _mapper.Map<GetCustomerOrderDto>(c)).ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetOrderProductsDto>>> GetOrderProducts(Guid Id)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderProductsDto>>();
            var products = await _context.OrderProducts
                .Include(p => p.Product)
                .Include(p => p.Order)
                .Where(c => c.Order.Id == Id)
                .ToListAsync();
            serviceResponse.Data = products.Select(c => _mapper.Map<GetOrderProductsDto>(c)).ToList();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCustomerOrderDto>>> GetOrdersByCustomer()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var serviceResponse = new ServiceResponse<List<GetCustomerOrderDto>>();
            var dbOrder = await _context.Orders
                  .Include(p => p.Customer)
                  .Include(p => p.Outlet)
                 .Where(c =>c.Customer.Id == Guid.Parse(UserId))
                 .ToListAsync();
            serviceResponse.Data = dbOrder.Select(c => _mapper.Map<GetCustomerOrderDto>(c)).ToList();
            return serviceResponse;

        }
    }
}
