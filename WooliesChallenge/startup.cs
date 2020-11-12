using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WooliesChallenge.Contracts;
using WooliesChallenge.Models;
using WooliesChallenge.Services;

[assembly: FunctionsStartup(typeof(WooliesChallenge.Startup))]

namespace WooliesChallenge
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Registering Configurations (IOptions pattern)
            builder
                .Services
                .AddOptions<UserConfig>()
                .Configure<IConfiguration>((UserSettings, configuration) =>
                {
                    configuration
                    .GetSection("User")
                    .Bind(UserSettings);
                });

            builder
                .Services
                .AddOptions<ResourceConfig>()
                .Configure<IConfiguration>((ResourceSettings, configuration) =>
                {
                    configuration
                    .GetSection("Resource")
                    .Bind(ResourceSettings);
                });

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<ISortService, SortService>();
            builder.Services.AddSingleton<IResourceService, ResourceService>();
        }
    }
}