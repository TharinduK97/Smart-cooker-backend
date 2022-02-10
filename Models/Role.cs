using System;
using System.Collections.Generic;

namespace Smart_Cookers.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public List<StaffMember> StaffMembers { get; set; }
    }
}
