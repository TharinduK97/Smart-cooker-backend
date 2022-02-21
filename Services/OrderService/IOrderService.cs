using Smart_Cookers.Dtos.OrderDtos;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetCustomerOrderDto>>> AddNewOrder(AddOrderDto newOrder);
        Task<ServiceResponse<List<GetCustomerOrderDto>>> GetOrdersByCustomer();
        Task<ServiceResponse<List<GetOrderProductsDto>>> GetOrderProducts(Guid Id);


    }
}
