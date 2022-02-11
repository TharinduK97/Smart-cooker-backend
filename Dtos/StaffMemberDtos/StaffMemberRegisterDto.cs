using Smart_Cookers.Models;

namespace Smart_Cookers.Dtos.StaffMemberDtos
{
    public class StaffMemberRegisterDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        

    }
}
