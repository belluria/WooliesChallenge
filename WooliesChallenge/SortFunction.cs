using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using WooliesChallenge.Models;
using WooliesChallenge.Contracts;
using System.Net.Http;
using WooliesChallenge.Services;
using System.Net;
using WooliesChallenge.Utils;

namespace WooliesChallenge
{
    public class SortFunction
    {
        private readonly ISortService _sortService;
        public SortFunction(ISortService sortService)
        {
            _sortService = sortService;
        }

        [FunctionName("sort")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "sort/{sortOption}")] HttpRequest req,
            string sortOption,
            ILogger log)
        {
            try
            {
                log.LogInformation("sort function processing a request.");
                return new OkObjectResult(_sortService.GetProductsInSortedOrder(ApiInputParser.GetSortOption(sortOption)));
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Exception occurred. SortOption: {0}", sortOption);
                return new StatusCodeResult(500);
            }
        }
    }
}
