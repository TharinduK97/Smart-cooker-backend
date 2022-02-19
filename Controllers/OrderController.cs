using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.OrderDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.OrderService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerOrderDto>>>> AddProduct(AddOrderDto newOrder)
        {
            return Ok(await _orderService.AddNewOrder(newOrder));
        }

        [Authorize]
        [HttpGet("GetOderByCustomer")]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerOrderDto>>>> Get()
        {
            return Ok(await _orderService.GetOrdersByCustomer());
        }
    }
}
