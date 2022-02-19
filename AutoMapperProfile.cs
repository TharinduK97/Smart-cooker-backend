using AutoMapper;
using Smart_Cookers.Dtos.AddressDtos;
using Smart_Cookers.Dtos.CustomerDtos;
using Smart_Cookers.Dtos.ImageDtos;
using Smart_Cookers.Dtos.OrderDtos;
using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Dtos.ProductDtos;
using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Dtos.StaffMemberDtos;
using Smart_Cookers.Models;

namespace Smart_Cookers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Role, GetRoleDto>();
            CreateMap<AddRoleDto, Role>();
            CreateMap<Outlet, GetOutletOrderDto>();
            CreateMap<Outlet, GetOutletDto>();
            CreateMap<Outlet, GetAssignProductDto>();
            CreateMap<OutletProduct, GetOutletProductDto>();
            CreateMap<AddOutletDto, Outlet>();
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<Address, GetAddressDto>();
            CreateMap<AddAddressDto, Address>();
            CreateMap<AssignProdcutDto, OutletProduct>();
            CreateMap<StaffMember, GetStaffMemberDto>();
            CreateMap<AddOrderDto, Order>();
            CreateMap<AddOrderProductDto, OrderProduct>();
            CreateMap<Order, GetCustomerOrderDto>();
            
                 CreateMap<OutletProduct, GetSingleOutletProductDto>();

        }
       
    }
}
