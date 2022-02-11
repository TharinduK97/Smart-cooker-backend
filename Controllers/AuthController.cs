using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.StaffMemberDtos;
using Smart_Cookers.Models;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;

        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(StaffMemberRegisterDto request)
        {
            var response = await _authRepo.Register(
                new StaffMember
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    WorkingStatus = request.WorkingStatus,
                   
                }
                , request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(StaffMemberLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Email, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


    }
}
