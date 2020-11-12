using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesChallenge.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
