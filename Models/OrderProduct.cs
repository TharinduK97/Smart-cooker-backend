﻿using System;

namespace Smart_Cookers.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}