using Smart_Cookers.Models;

namespace Smart_Cookers.Dtos.StaffMemberDtos
{
    public class GetStaffMemberDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public Role Role { get; set; }
        public Outlet Outlet { get; set; }
    }
}
