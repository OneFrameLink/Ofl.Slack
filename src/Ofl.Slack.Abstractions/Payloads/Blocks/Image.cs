using Ofl.Slack.Payloads.Composition;
using System;

namespace Ofl.Slack.Payloads
{
    public class Image : Block
    {
        #region Constructor

        public Image(
            string imageUrl,
            string altText,
            TextObject? title = null,
            string? blockId = null
        ) : base(blockId)
        {
            // Validate parameters.
            ImageUrl = string.IsNullOrWhiteSpace(imageUrl)
                ? throw new ArgumentNullException(nameof(imageUrl))
                : imageUrl;
            AltText = string.IsNullOrWhiteSpace(altText)
                ? throw new ArgumentNullException(nameof(altText))
                : altText;

            // Assign values.
            Title = title;
        }

        #endregion

        #region Instance, read-only state.

        public override string Type => "image";

        public string ImageUrl { get; }

        public string AltText { get; }

        public TextObject? Title { get; }

        #endregion
    }
}
