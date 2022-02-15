﻿using AutoMapper;
using Smart_Cookers.Dtos.AddressDtos;
using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Dtos.ImageDtos;
using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Models;

namespace Smart_Cookers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Role, GetRoleDto>();
            CreateMap<AddRoleDto, Role>();
            CreateMap<Outlet, GetOutletDto>();
            CreateMap<Outlet, GetAssignProductDto>();
            CreateMap<OutletProduct, GetOutletProductDto>();
            CreateMap<AddOutletDto, Outlet>();
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Image, GetImageDto>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<Address, GetAddressDto>();
            CreateMap<AssignProdcutDto, OutletProduct>();
        }
       
    }
}
