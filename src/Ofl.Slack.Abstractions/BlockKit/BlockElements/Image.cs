using System;
using System.Collections.Generic;
using System.Text;

namespace Ofl.Slack.BlockKit.BlockElements
{
    public class Image : BlockElement
    {
        #region Constructor

        public Image(
            string imageUrl,
            string altText
        )
        {
            // Validate parameters.
            ImageUrl = string.IsNullOrWhiteSpace(imageUrl)
                ? throw new ArgumentNullException(nameof(imageUrl))
                : imageUrl;
            AltText = string.IsNullOrWhiteSpace(altText)
                ? throw new ArgumentNullException(nameof(altText))
                : altText;
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "image";

        public string ImageUrl { get; }

        public string AltText { get; }

        #endregion
    }
}
