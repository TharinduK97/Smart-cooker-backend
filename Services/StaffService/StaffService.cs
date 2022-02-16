using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Data;
using Smart_Cookers.Dtos.StaffMemberDtos;
using Smart_Cookers.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_Cookers.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StaffService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<GetStaffMemberDto>> GetStaffById()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var serviceResponse = new ServiceResponse<GetStaffMemberDto>();
            var dbStaff = await _context.StaffMembers
                  .Include(p => p.Role)
                 .FirstOrDefaultAsync(c => c.Id == Guid.Parse(UserId));

            serviceResponse.Data = _mapper.Map<GetStaffMemberDto>(dbStaff);
            return serviceResponse;
        }
    }
}
