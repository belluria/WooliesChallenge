using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesChallenge.Models
{
    public class ProductsPopular : Product
    {
        public ProductsPopular()
        {
        }

        public ProductsPopular(Product product, long TotalOrders, long TotalQuantity) : base(product)
        {
            this.TotalOrders = TotalOrders;
            this.TotalQuantity = TotalQuantity;
        }
        
        public long TotalOrders {get; set;}
        public long TotalQuantity { get; set; }

        public Product ToProduct()
        {
            return (Product)this;
        }
    }
}
