using Ofl.Slack.WebApi.Methods.Files;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Slack.Tests
{
    public partial class WebApiTests : IClassFixture<WebApiTestsFixture>
    {
        #region Tests

        [Fact]
        public async Task Test_UploadFile()
        {
            // The cancellation token.
            CancellationToken cancellationToken = CancellationToken.None;

            // The content.
            var file = new StringContent("File content");

            // Create the request.
            var request = new UploadRequest(
                file,
                "test",
                filetype: "text",
                initialComment: "This is the initial comment",
                title: "file title"
            );

            // Post a message.
            var response = await Client.Files
                .UploadAsync(request, cancellationToken)
                .ConfigureAwait(false);

            // It is ok.
            Assert.True(response.Ok, $"The call to {nameof(Client.Files.UploadAsync)} returned an error: {response.Error}");

            // Assert value equality.
            Assert.Equal(request.Filename, response.File.Name);
            Assert.Equal(request.Title, response.File.Title);
        }

        #endregion
    }
}
