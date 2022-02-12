using System;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cookers.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string DoorNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }
        public Customer Customer { get; set; }
    }
}
