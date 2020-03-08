using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ofl.Slack.WebApi;
using System;

namespace Ofl.Slack
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSlack(
            this IServiceCollection serviceCollection,
            IConfiguration slackConfiguration
        )
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
            if (slackConfiguration == null) throw new ArgumentNullException(nameof(slackConfiguration));

            // Add the web API.
            sc = sc.AddWebApi(slackConfiguration);

            // Return the collection.
            return sc;
        }
    }
}
