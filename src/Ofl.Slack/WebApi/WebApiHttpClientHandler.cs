using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Net.Http;

namespace Ofl.Slack.WebApi
{
    public class WebApiHttpClientHandler : HttpClientHandler
    {
        #region Constructor

        public WebApiHttpClientHandler(
            IWebApiTokenProvider webApiTokenProvider
        )
        {
            // Validate parameters.
            _webApiTokenProvider = webApiTokenProvider
                ?? throw new ArgumentNullException(nameof(webApiTokenProvider));

            // Set decompression.
            this.SetCompression();
        }

        #endregion

        #region Instance, read-only state

        private readonly IWebApiTokenProvider _webApiTokenProvider;

        #endregion

        #region Overrides of HttpClientHandler

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Add the authorization.
            request.Headers.Authorization = 
                new AuthenticationHeaderValue("Bearer", _webApiTokenProvider.Token);

            // Call the base.
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}