using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.RoleService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleservice;

        public RoleController(IRoleService roleservice)
        {
            _roleservice = roleservice;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetRoleDto>>>> Get()
        {
            return Ok(await _roleservice.GetAllRoles());
        }
       

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetRoleDto>>>> AddRole(AddRoleDto newrole)
        {
            return Ok(await _roleservice.AddRole(newrole));
        }




    }
}
