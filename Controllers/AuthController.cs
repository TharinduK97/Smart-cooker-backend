using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.CustomerDtos;
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
        private readonly ICustomerAuthRepository _authCustomerRepo;

        public AuthController(IAuthRepository authRepo, ICustomerAuthRepository authCustomerRepo)
        {
            _authRepo = authRepo;
            _authCustomerRepo = authCustomerRepo;

        }
        [HttpPost("StaffRegister")]
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

        [HttpPost("CustomerRegister")]
        public async Task<ActionResult<ServiceResponse<int>>> CustomerRegister(CustomerRegisterDto request)
        {
            var response = await _authCustomerRepo.CustomerRegister(
                new Customer
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Nic=request.Nic,

                }
                , request.Password,
                new Address
                {
                    DoorNumber = request.DoorNumber,
                    Street = request.Street,
                    City = request.City,

                }
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("StaffLogin")]
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

        [HttpPost("CustomerLogin")]
        public async Task<ActionResult<ServiceResponse<string>>> CustomerLogin(StaffMemberLoginDto request)
        {
            var response = await _authCustomerRepo.Login(
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
