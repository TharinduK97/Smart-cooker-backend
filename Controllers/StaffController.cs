using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.StaffMemberDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.StaffService;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffservice;

        public StaffController(IStaffService staffeservice)
        {
            _staffservice = staffeservice;

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetStaffMemberDto>>> GetSingleStaff()
        {
            return Ok(await _staffservice.GetStaffById());
        }
    }
}
