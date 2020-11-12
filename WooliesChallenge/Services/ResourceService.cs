using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesChallenge.Models;
using WooliesChallenge.Contracts;
using Microsoft.Extensions.Options;

namespace WooliesChallenge.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ResourceConfig _resourceConfig;

        public ResourceService(IOptions<ResourceConfig> resourceConfig)
        {
            _resourceConfig = resourceConfig.Value;
        }
        public List<Product> GetProducts()
        {
            string urlProducts = _resourceConfig.url + "api/resource/products";
            var result = this.GetResource<List<Product>>(urlProducts).Result;
            if (result == default(List<Product>))
            {
                throw new ApplicationException("Failed to get products");
            }
            return result;
        }

        public List<ShopperHistory> GetShopperHistory()
        {
            string urlShopperHistory = _resourceConfig.url + "api/resource/shopperHistory";
            var result = this.GetResource<List<ShopperHistory>>(urlShopperHistory).Result;
            if (result == default(List<ShopperHistory>))
            {
                throw new ApplicationException("Failed to get products");
            }
            return result;
        }

        private async Task<T> GetResource<T>(string urlPath)
        {
            RestClient client = new RestClient(urlPath);
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("ContentType", "application/json");
            restRequest.AddHeader("token", _resourceConfig.token);
            IRestResponse<T> restResponse = await client.ExecuteAsync<T>(restRequest);
            return restResponse.Data;
        }
    }
}
