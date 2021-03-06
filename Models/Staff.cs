using System;

namespace Smart_Cookers.Models
{
    public enum WorkingStatus
    {
        Active,
        NotActive
    }
    public class Staff
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public WorkingStatus WorkingStatus { get; set; }

    }
}
