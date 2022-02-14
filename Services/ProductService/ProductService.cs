using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ProductService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;

        }

        private Guid GetUserId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            Product product = _mapper.Map<Product>(new Product
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
                Price = newProduct.Price,
                Quantity = newProduct.Quantity
            });
            product.StaffMember = await _context.StaffMembers.FirstOrDefaultAsync(u => u.Id == GetUserId());
           
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
             _context.Images.Add(new Image
            {
                Product = product,
                ImageUrl= newProduct.ImageUrl
            });
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Products
                .Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products
                .Include(p => p.Images)
                .ToListAsync();
            //: await _context.AppliedJobs.Where(c => c.User.ID == GetUserId()).ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssignProductDto>>> GetProductsByOutlet(string OutletId)
        {
            var serviceResponse = new ServiceResponse<List<GetAssignProductDto>>();
            var dbOutletProduct = await _context.OutletProducts.            
                Where(c => c.OutletId == Guid.Parse(OutletId)).ToListAsync();
            serviceResponse.Data = dbOutletProduct.Select(c => _mapper.Map<GetAssignProductDto>(c)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetAssignProductDto>>> AssignProduct(AssignProdcutDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetAssignProductDto>>();

            OutletProduct  outletProduct = _mapper.Map<OutletProduct>(newProduct);
            outletProduct.Product = await _context.Products.FirstOrDefaultAsync(u => u.Id == newProduct.ProductId);
            outletProduct.Outlet = await _context.Outlets.FirstOrDefaultAsync(u => u.Id == newProduct.OutletId);

            _context.OutletProducts.Add(outletProduct);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.OutletProducts
                  .Select(c => _mapper.Map<GetAssignProductDto>(c)).ToListAsync();
            return serviceResponse;
        }

    }
}
