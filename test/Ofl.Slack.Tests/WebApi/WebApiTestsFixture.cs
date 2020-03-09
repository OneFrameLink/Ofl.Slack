using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ofl.Slack.WebApi;

namespace Ofl.Slack.Tests
{
    public class WebApiTestsFixture : IDisposable
    {
        #region Constructor

        public WebApiTestsFixture()
        {
            // Assign values.
            _serviceProvider = CreateServiceProvider();
        }

        #endregion

        #region Read-only state.

        private static readonly IConfigurationRoot ConfigurationRoot = new ConfigurationBuilder()
            // For local debugging.
            .AddJsonFile("appsettings.local.json", true)
            // For Appveyor.
            .AddEnvironmentVariables()
            .Build();

        private readonly ServiceProvider _serviceProvider;

        #endregion

        #region Helpers

        private static ServiceProvider CreateServiceProvider()
        {
            // Create a collection.
            IServiceCollection sc = new ServiceCollection();

            // Add the google apis.
            sc = sc.AddSlack(ConfigurationRoot.GetSection("slack"));

            // Build and return.
            return sc.BuildServiceProvider();
        }

        public IWebApi CreateWebApi() => _serviceProvider.GetRequiredService<IWebApi>();

        public string Channel => ConfigurationRoot.GetSection("slack").GetSection("channel").Get<string>();

        #endregion

        #region IDisposable implementation.

        public void Dispose()
        {
            // Call the overload and
            // suppress finalization.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            // Dispose of unmanaged resources.

            // If not disposing, get out.
            if (!disposing) return;

            // Dispose of IDisposable implementations.
            using var _ = _serviceProvider;
        }

        ~WebApiTestsFixture() => Dispose(false);

        #endregion
    }
}
