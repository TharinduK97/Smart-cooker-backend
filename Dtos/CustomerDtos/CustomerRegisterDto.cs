using Smart_Cookers.Models;

namespace Smart_Cookers.Dtos.CustomerDtos
{
    public class CustomerRegisterDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Nic { get; set; }

        public string DoorNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
    }
}
