using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WooliesChallenge.Models;

namespace WooliesChallenge.Helpers
{
    public static class ProductExtensions
    {
        public static List<Product> Sort(this List<Product> products, SortOption sortOption)
        {
            if (products == null || products.Count == 0)
            {
                return products;
            }

            List<Product> result;
            switch(sortOption)
            {
                case SortOption.High:
                    result = products.OrderByDescending(p => p.Price).ToList();
                    break;

                case SortOption.Low:
                    result = products.OrderBy(p => p.Price).ToList();
                    break;

                case SortOption.Ascending:
                    result = products.OrderBy(n => n.Name).ToList();
                    break;

                case SortOption.Descending:
                    result = products.OrderByDescending(n => n.Name).ToList();
                    break;

                default:
                    result = products;
                    break;
            }

            return result;
        }

    }
}
