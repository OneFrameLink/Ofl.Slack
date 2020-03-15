using Ofl.Net.Http.ApiClient.Json;
using Ofl.Slack.BlockKit.Blocks;
using Ofl.Slack.Serialization.Text.Json;
using Ofl.Slack.WebApi.Methods.Chat;
using Ofl.Text.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi
{
    public class WebApi : JsonApiClient, IWebApi
    {
        #region Constructor

        public WebApi(HttpClient httpClient) : base(httpClient, true)
        {
            // Assign values.
            Chat = new ChatMethods(this);
        }

        static WebApi()
        {
            // Create the snake case naming policy.
            var snakeCaseNamingPolicy = new SnakeCaseJsonNamingPolicy(true);

            // Set the options.
            JsonSerializerOptions = new JsonSerializerOptions {
                PropertyNamingPolicy = snakeCaseNamingPolicy,
                Converters = {
                    new JsonStringEnumConverter(snakeCaseNamingPolicy, false),
                    new PolymorphicReadOnlyCollectionJsonConverter<Block>()
                },
                IgnoreNullValues = true
            };
        }

        #endregion

        #region Read-only state

        private static readonly JsonSerializerOptions JsonSerializerOptions;

        public IChatMethods Chat { get; }

        #endregion

        #region Overrides

        protected override JsonSerializerOptions CreateJsonSerializerOptions() => JsonSerializerOptions;

        protected override ValueTask<string> FormatUrlAsync(string url, CancellationToken cancellationToken) =>
            new ValueTask<string>("https://slack.com/api/" + url);

        #endregion

        #region Helpers

        internal Task<TResponse> PostToWebApiAsync<TRequest, TResponse>(
            string url,
            TRequest request,
            CancellationToken cancellationToken) => base.PostAsync<TRequest, TResponse>(url, request, cancellationToken);

        #endregion
    }
}
