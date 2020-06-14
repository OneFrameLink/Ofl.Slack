using Ofl.BlockKit.Payloads;
using Ofl.Slack.BlockKit.Blocks;
using Ofl.Slack.BlockKit.Composition;
using Ofl.Slack.WebApi.Methods.Chat;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Slack.Tests
{
    public partial class WebApiTests : IClassFixture<WebApiTestsFixture>
    {
        #region Tests

        [Fact]
        public async Task Test_PostMessage_With_Text_Async()
        {
            // Post a message.
            var response = await Client.Chat.PostMessageAsync(
                new PostMessageRequest(
                    Fixture.Channel,
                    $"Test: {nameof(Test_PostMessage_With_Text_Async)} executed at {DateTimeOffset.Now}."
                )
            )
            .ConfigureAwait(false);

            // Verify it posted without error
            // and without warning.
            Assert.True(response.Ok,
                $"The call to {nameof(Client.Chat.PostMessageAsync)} failed - Error: {response.Error}"
            );
            Assert.True(string.IsNullOrWhiteSpace(response.Warning),
                $"The call to {nameof(Client.Chat.PostMessageAsync)} produced a warning - Warning: {response.Warning}"
            );
        }

        [Fact]
        public async Task Test_PostMessage_With_Mixed_Blocks_Async()
        {
            // Create the request.
            var request = new PostMessageRequest(
                Fixture.Channel,
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
            var response = await Client.Chat
                .PostMessageAsync(request)
                .ConfigureAwait(false);

            // Verify it posted without error
            // and without warning.
            Assert.True(response.Ok,
                $"The call to {nameof(Client.Chat.PostMessageAsync)} failed - Error: {response.Error}"
            );
            Assert.True(string.IsNullOrWhiteSpace(response.Warning),
                $"The call to {nameof(Client.Chat.PostMessageAsync)} produced a warning - Warning: {response.Warning}"
            );
        }

        #endregion
    }
}
