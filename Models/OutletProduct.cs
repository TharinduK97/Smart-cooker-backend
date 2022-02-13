using System;

namespace Smart_Cookers.Models
{
    public class OutletProduct
    {
        
        public Guid Id { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid OutletId { get; set; }
        public Outlet Outlet { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
