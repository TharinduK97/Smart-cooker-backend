using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public RoleService(IMapper mapper, DataContext context)
        {
         
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetRoleDto>>> AddRole(AddRoleDto newRole)
        {
            var serviceResponse = new ServiceResponse<List<GetRoleDto>>();
            Role role = _mapper.Map<Role>(newRole);
           
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Roles
                .Select(c => _mapper.Map<GetRoleDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRoleDto>>> GetAllRoles()
        {
            var serviceResponse = new ServiceResponse<List<GetRoleDto>>();
            var DbRoles = await _context.Roles.ToListAsync();
            serviceResponse.Data = DbRoles.Select(c => _mapper.Map<GetRoleDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
