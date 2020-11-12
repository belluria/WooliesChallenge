using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using WooliesChallenge.Models;
using WooliesChallenge.Services;
using WooliesChallenge.Contracts;
using System.Web.Http;

namespace WooliesChallenge
{
    public class UserFunction
    {
        private readonly IUserService _userService;

        public UserFunction(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("user")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("user function processing a request.");
                UserConfig user = _userService.GetUserDetails();
                if (user == null)
                {
                    return new NotFoundObjectResult("Failed to retrieve user name and token from App Configuration");
                }
                return new OkObjectResult(user);
            }
            catch
            {
                return new InternalServerErrorResult();
            }
        }
    }
}
