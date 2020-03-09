using Ofl.Slack.WebApi;
using Ofl.Slack.WebApi.Methods.Chat;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Slack.Tests
{
    public class WebApiTests : IClassFixture<WebApiTestsFixture>
    {
        #region Constructor

        public WebApiTests(WebApiTestsFixture fixture)
        {
            // Validate parameters.
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        #endregion

        #region Instance, read-only state

        private readonly WebApiTestsFixture _fixture;

        #endregion

        #region Tests

        [Fact]
        public async Task Test_PostMessageAsync()
        {
            // Create the slack client.
            IWebApi client = _fixture.CreateWebApi();

            // Post a message.
            var response = await client.Chat.PostMessageAsync(
                new PostMessageRequest(
                    _fixture.Channel,
                    $"Test: {nameof(Test_PostMessageAsync)} executed at {DateTimeOffset.Now}."
                )
            )
            .ConfigureAwait(false);

            // Verify it posted.
            Assert.True(response.Ok);            
        }

        #endregion
    }
}
