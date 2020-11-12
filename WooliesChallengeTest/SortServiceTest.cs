using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WooliesChallenge.Contracts;
using WooliesChallenge.Models;
using WooliesChallenge.Services;
using Xunit;

namespace WooliesChallengeTest
{
    public class SortServiceTest
    {
        private readonly List<Product> _products;
        private readonly List<ShopperHistory> _shopperHistories;
        private readonly ISortService _sortService;

        public SortServiceTest()
        {
            _products = new List<Product> { new Product { Name = "Product2", Price = 1.9M, Quantity = 5 },
                                                         new Product { Name = "Product1", Price = 2.5M, Quantity = 4 },
                                                         new Product { Name = "Product3", Price = 3.0M, Quantity = 6 }
                                                       };

            _shopperHistories = new List<ShopperHistory>
                                                    {
                                                        new ShopperHistory
                                                        {
                                                            CustomerId = 1,
                                                            Products = new List<Product>
                                                            {
                                                                new Product { Name = "Product4", Price = 4.2M, Quantity = 2},
                                                                new Product { Name = "Product5", Price = 5.1M, Quantity = 10}
                                                            },
                                                        },
                                                        new ShopperHistory
                                                        {
                                                            CustomerId = 2,
                                                            Products = new List<Product>
                                                            { 
                                                                new Product { Name = "Product4", Price = 4.2M, Quantity = 10},
                                                                new Product { Name = "Product5", Price = 5.1M, Quantity = 10}
                                                            }
                                                        },
                                                        new ShopperHistory
                                                        {
                                                            CustomerId = 3,
                                                            Products = new List<Product>
                                                            {
                                                                new Product { Name = "Product4", Price = 4.2M, Quantity = 1},
                                                                new Product { Name = "Product8", Price = 5.1M, Quantity = 100}
                                                            }
                                                        },
                                                        new ShopperHistory
                                                        {
                                                            CustomerId = 4,
                                                            Products = new List<Product>
                                                            {
                                                                new Product { Name = "Product6", Price = 6.3M, Quantity = 200 }
                                                            }
                                                        }
            };

            Mock<IResourceService> _moqResourceService = new Mock<IResourceService>();
            _moqResourceService.Setup(p => p.GetProducts()).Returns(_products);
            _moqResourceService.Setup(p => p.GetShopperHistory()).Returns(_shopperHistories);
            _sortService = new SortService(_moqResourceService.Object);
        }

        [Fact]
        private void TestSortProductsByLow()
        {
            List<Product> products = _sortService.GetProductsInSortedOrder(SortOption.Low);

            Assert.Equal<int>(3, products.Count);
            Assert.Equal("Product2", products[0].Name);
            Assert.Equal("Product3", products[products.Count - 1].Name);
        }

        [Fact]
        private void TestSortProductsByHigh()
        {
            List<Product> products = _sortService.GetProductsInSortedOrder(SortOption.High);

            Assert.Equal<int>(3, products.Count);
            Assert.Equal("Product3", products[0].Name);
            Assert.Equal("Product2", products[products.Count - 1].Name);
        }

        [Fact]
        private void TestSortProductsByAscending()
        {
            List<Product> products = _sortService.GetProductsInSortedOrder(SortOption.Ascending);

            Assert.Equal<int>(3, products.Count);
            Assert.Equal("Product1", products[0].Name);
            Assert.Equal("Product3", products[products.Count - 1].Name);
        }

        [Fact]
        private void TestSortProductsByDescending()
        {
            List<Product> products = _sortService.GetProductsInSortedOrder(SortOption.Descending);

            Assert.Equal<int>(3, products.Count);
            Assert.Equal("Product3", products[0].Name);
            Assert.Equal("Product1", products[products.Count - 1].Name);
        }

        [Fact]
        private void TestSortProductsByRecommendation()
        {
            List<Product> products = _sortService.GetProductsInSortedOrder(SortOption.Recommended);

            Assert.Equal<int>(4, products.Count);
            Assert.Equal("Product4", products[0].Name);
            Assert.Equal("Product5", products[1].Name);
            Assert.Equal("Product6", products[2].Name);
            Assert.Equal("Product8", products[3].Name);
        }
    }
}
