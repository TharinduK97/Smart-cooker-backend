using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<List<GetAssignProductDto>>> GetProductsByOutlet(Guid Id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<List<GetAssignProductDto>>> AssignProduct(AssignProdcutDto newProduct);
    }
}
