using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Cookers.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nic { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}
