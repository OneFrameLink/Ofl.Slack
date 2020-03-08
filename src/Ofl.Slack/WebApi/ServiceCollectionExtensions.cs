using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ofl.Slack.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebApi(
            this IServiceCollection serviceCollection,
            IConfiguration slackConfiguration
        )
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
            if (slackConfiguration == null) throw new ArgumentNullException(nameof(slackConfiguration));

            // Add the token provider configuration.
            sc = sc.Configure<WebApiTokenProviderConfiguration>(slackConfiguration.Bind);

            // Get the token provider.
            sc = sc.AddTransient<IWebApiTokenProvider, WebApiTokenProvider>();

            // Configure the client handler.
            sc = sc.AddTransient<WebApiHttpClientHandler>();

            // Add the http client and handler.
            sc.AddHttpClient<IWebApi, WebApi>()
                .ConfigurePrimaryHttpMessageHandler<WebApiHttpClientHandler>();

            // Return the collection.
            return sc;
        }
    }
}
