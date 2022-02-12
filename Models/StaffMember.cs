using System;
using System.Collections.Generic;

namespace Smart_Cookers.Models
{
    public enum WorkingStatus
    {
        Active,
        NotActive
    }
    public class StaffMember
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public Role Role { get; set; }
        public Outlet Outlet { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
