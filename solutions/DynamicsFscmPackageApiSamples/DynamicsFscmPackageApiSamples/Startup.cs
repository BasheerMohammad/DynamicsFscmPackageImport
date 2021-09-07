using DynamicsFscmPackageApiSamples.Common;
using DynamicsFscmPackageApiSamples.Common.Authentication;
using DynamicsFscmPackageApiSamples.Services;
using DynamicsFscmPackageApiSamples.Services.Common.Clients;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

[assembly: FunctionsStartup(typeof(DynamicsFscmPackageApiSamples.Startup))]
namespace DynamicsFscmPackageApiSamples
{
    [ExcludeFromCodeCoverage]
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();

            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient<IDynamicsFscmApiClient, DynamicsFscmApiClient>(client =>
            {
                client.BaseAddress = new Uri(context.Configuration["DynamicsFscm:BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", nameof(ApiClient));
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
                client.Timeout = new TimeSpan(0, 1, 0);
            })
            .AddHttpMessageHandler<ApiClientBearerTokenHandler<IDynamicsFscmAuthClient>>();

            builder.Services.AddTransient<ApiClientBearerTokenHandler<IDynamicsFscmAuthClient>>();
            builder.Services.AddSingleton<IDynamicsFscmAuthClient>(serviceProvider =>
            {
                var options = context.Configuration.GetSection("DynamicsFscm").Get<AuthOptions>();
                var apiAuthClient = new DynamicsFscmAuthClient(options);
                return apiAuthClient;
            });            

            // Services
            builder.Services.AddTransient<IDataManagementPackageApiService, DataManagementPackageApiService>();
        }
    }
}