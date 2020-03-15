using Ofl.BlockKit.Payloads;
using Ofl.Slack.BlockKit.Blocks;
using Ofl.Slack.BlockKit.Composition;
using Ofl.Slack.WebApi;
using Ofl.Slack.WebApi.Methods.Chat;
using System;
using System.Collections.Generic;
using System.Text.Json;
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
        public async Task Test_PostMessage_With_Text_Async()
        {
            // Create the slack client.
            IWebApi client = _fixture.CreateWebApi();

            // Post a message.
            var response = await client.Chat.PostMessageAsync(
                new PostMessageRequest(
                    _fixture.Channel,
                    $"Test: {nameof(Test_PostMessage_With_Text_Async)} executed at {DateTimeOffset.Now}."
                )
            )
            .ConfigureAwait(false);

            // Verify it posted without error
            // and without warning.
            Assert.True(response.Ok,
                $"The call to {nameof(client.Chat.PostMessageAsync)} failed - Error: {response.Error}"
            );
            Assert.True(string.IsNullOrWhiteSpace(response.Warning),
                $"The call to {nameof(client.Chat.PostMessageAsync)} produced a warning - Warning: {response.Warning}"
            );
        }

        [Fact]
        public async Task Test_PostMessage_With_Mixed_Blocks_Async()
        {
            // Create the slack client.
            IWebApi client = _fixture.CreateWebApi();

            // Create the request.
            var request = new PostMessageRequest(
                _fixture.Channel,
                "Text",
                blocks: new Block[] {
                    new Section(
                        new TextObject(
                            TextType.Mrkdwn,
                            $"Test: {nameof(Test_PostMessage_With_Text_Async)} executed at {DateTimeOffset.Now}."
                        )
                    ),
                    new Divider()
                }
            );

            // Post a message.
            var response = await client.Chat
                .PostMessageAsync(request)
                .ConfigureAwait(false);

            // Verify it posted without error
            // and without warning.
            Assert.True(response.Ok,
                $"The call to {nameof(client.Chat.PostMessageAsync)} failed - Error: {response.Error}"
            );
            Assert.True(string.IsNullOrWhiteSpace(response.Warning),
                $"The call to {nameof(client.Chat.PostMessageAsync)} produced a warning - Warning: {response.Warning}"
            );
        }

        #endregion
    }
}
