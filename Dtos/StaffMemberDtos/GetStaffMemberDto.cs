using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Dtos.RoleDtos;
using Smart_Cookers.Models;
using System;

namespace Smart_Cookers.Dtos.StaffMemberDtos
{
    public class GetStaffMemberDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public GetRoleDto Role { get; set; }
        //public GetOutletDto Outlet { get; set; }
    }
}
