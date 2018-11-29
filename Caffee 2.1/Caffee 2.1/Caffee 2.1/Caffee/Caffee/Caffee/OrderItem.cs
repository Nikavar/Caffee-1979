using System;
using System.Collections.Generic;
using System.Text;

namespace Caffee
{
    public class OrderItem
    {
        public int Id { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public Product product { get; set; }

        public string DisplayName { get => product.ProductName; }
        public double ProductPrice { get => product.Price * Quantity; }
    }
}
