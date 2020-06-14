using Ofl.Slack.WebApi;
using System;
using Xunit;

namespace Ofl.Slack.Tests
{
    public partial class WebApiTests : IClassFixture<WebApiTestsFixture>
    {
        #region Constructor

        public WebApiTests(WebApiTestsFixture fixture)
        {
            // Validate parameters.
            Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

            // Assign values.
            Client = fixture.CreateWebApi();

        }

        #endregion

        #region Instance, read-only state

        private IWebApi Client { get; }

        private WebApiTestsFixture Fixture { get; }

        #endregion
    }
}
