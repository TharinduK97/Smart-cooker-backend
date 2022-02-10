using AutoMapper;
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
        }
       
    }
}
