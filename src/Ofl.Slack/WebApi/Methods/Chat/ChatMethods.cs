using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi.Methods.Chat
{
    internal class ChatMethods : IChatMethods
    {
        #region Constructor

        public ChatMethods(WebApi webApi)
        {
            // Validate parameters.
            _webApi = webApi;
        }

        #endregion

        #region Instance, read-only state

        private readonly WebApi _webApi;

        #endregion

        #region IChatMethods implementation

        #endregion
        public Task<PostMessageResponse> PostMessageAsync(
            PostMessageRequest request, 
            CancellationToken cancellationToken = default
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Post the request.
            return _webApi.PostToWebApiAsync<PostMessageRequest, PostMessageResponse>(
                "chat.postMessage", 
                request, 
                cancellationToken
            );
        }
    }
}
