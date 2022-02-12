using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cookers.Models
{
    public class Outlet
    {
        public  Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public int DoorNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }
        public List<StaffMember> StaffMembers { get; set; }
        public List<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<OutletProduct> OutletProducts { get; set; }



    }
}
