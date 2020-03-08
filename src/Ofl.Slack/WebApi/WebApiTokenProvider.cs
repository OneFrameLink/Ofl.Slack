using Microsoft.Extensions.Options;
using System;

namespace Ofl.Slack.WebApi
{
    public class WebApiTokenProvider : IWebApiTokenProvider
    {
        #region Constructor

        public WebApiTokenProvider(IOptions<WebApiTokenProviderConfiguration>
            webApiTokenProviderConfigurationOptions
        )
        {
            // Validate parameters.
            _webApiTokenProviderConfigurationOptions = webApiTokenProviderConfigurationOptions
                ?? throw new ArgumentNullException(nameof(webApiTokenProviderConfigurationOptions));
        }

        #endregion

        #region Instance, read-only state

        private readonly IOptions<WebApiTokenProviderConfiguration> _webApiTokenProviderConfigurationOptions;

        public string Token { 
            get
            {
                // Get the token.
                string? token = _webApiTokenProviderConfigurationOptions.Value.Token;

                // If null or whitespace, throw.
                if (string.IsNullOrWhiteSpace(token))
                    throw new InvalidOperationException("Encountered a null value for token passed in through configuration.");

                // Return.
                return token;
            }
        }

        #endregion
    }
}
