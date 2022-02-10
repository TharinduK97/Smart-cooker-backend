using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<GetRoleDto>>> GetAllRoles();
        Task<ServiceResponse<List<GetRoleDto>>> AddRole(AddRoleDto newRole);
    }
}
