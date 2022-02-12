using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cookers.Models
{
   
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } 
        public int Quantity { get; set;} 
        public StaffMember StaffMember { get; set; }
        public List<Image> Images { get; set; }
        public ICollection<Order> Orders { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public ICollection<Outlet> Outlets { get; set; }
        public List<OutletProduct> OutletProducts { get; set; }

    }
}
