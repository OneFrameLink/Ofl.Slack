using Ofl.Slack.WebApi;
using Ofl.Slack.WebApi.Methods.Chat;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Slack.Tests
{
    public class SlackClientTests : IClassFixture<SlackClientTestsFixture>
    {
        #region Constructor

        public SlackClientTests(SlackClientTestsFixture fixture)
        {
            // Validate parameters.
            _slackClientTestsFixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        #endregion

        #region Instance, read-only state

        private readonly SlackClientTestsFixture _slackClientTestsFixture;

        #endregion

        #region Tests

        [Fact]
        public async Task Test_PostMessageAsync()
        {
            // Create the slack client.
            IWebApi client = _slackClientTestsFixture.CreateWebApi();

            // Post a message.
            var response = await client.Chat.PostMessageAsync(
                new PostMessageRequest(
                    _slackClientTestsFixture.Channel,
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
