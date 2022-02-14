using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.CustomerService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetSingleCustomer()
        {
            return Ok(await _customerService.GetCustomerById());
        }
    }
}
