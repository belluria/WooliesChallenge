using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesChallenge.Models;
using WooliesChallenge.Helpers;
using WooliesChallenge.Contracts;
using System.Linq;

namespace WooliesChallenge.Services
{
    public class SortService : ISortService
    {
        private readonly IResourceService _resourceService;

        public SortService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public List<Product> GetProductsInSortedOrder(SortOption sortOption)
        {
            return sortOption == SortOption.Recommended ? GetProductsSortedInRecomendedOrder() : _resourceService.GetProducts().Sort(sortOption);
        }

        private List<Product> GetProductsSortedInRecomendedOrder()
        {
            List<ShopperHistory> shopperHistories  = _resourceService.GetShopperHistory();
            Dictionary<string, ProductsPopular> dictProductsPopular = new Dictionary<string, ProductsPopular>();
            foreach(ShopperHistory shopperHistory in shopperHistories)
            {
                foreach(Product product in shopperHistory.Products)
                {
                    if (dictProductsPopular.ContainsKey(product.Name))
                    {
                        dictProductsPopular[product.Name].TotalOrders++;
                        dictProductsPopular[product.Name].TotalQuantity += product.Quantity;
                    }
                    else
                    {
                        dictProductsPopular.Add(product.Name, new ProductsPopular(product, 1, product.Quantity));
                    }
                }
            }
            return dictProductsPopular.Values.ToList().OrderByDescending(p => p.TotalOrders).ThenByDescending(p => p.TotalQuantity).Select(p => p.ToProduct()).ToList();
        }
    }
}
