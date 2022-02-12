using System;

namespace Smart_Cookers.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Product Product { get; set; }

    }
}
