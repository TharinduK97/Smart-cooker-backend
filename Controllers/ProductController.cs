using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetProductById(Guid Id)
        {
            return Ok(await _productService.GetSingleProduct(Id));
        }
        
        [HttpGet]
        [Route("Outlet/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAssignProductDto>>> GetProductByOutlet(Guid Id)
        {
            return Ok(await _productService.GetProductsByOutlet(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> Get()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost("AssignProduct")]
        public async Task<ActionResult<ServiceResponse<List<AssignProdcutDto>>>> AssignProduct(AssignProdcutDto newProduct)
        {
            return Ok(await _productService.AssignProduct(newProduct));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpGet("GetSingleProduct")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> GetSingleProductByOutlet(Guid ProductId,Guid OutletId)
        {
            return Ok(await _productService.GetSingleProductByOutlet( ProductId, OutletId));
        }
    }
}
