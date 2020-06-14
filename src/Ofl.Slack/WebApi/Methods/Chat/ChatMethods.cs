using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi.Methods.Chat
{
    internal class ChatMethods : Methods, IChatMethods
    {
        #region Constructor

        public ChatMethods(WebApi webApi) : base(webApi)
        { }

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
            return WebApi.PostToWebApiAsync<PostMessageRequest, PostMessageResponse>(
                "chat.postMessage", 
                request, 
                cancellationToken
            );
        }
    }
}
