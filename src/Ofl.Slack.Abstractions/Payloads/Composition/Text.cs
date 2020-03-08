using System;

namespace Ofl.Slack.Payloads.Composition
{
    public class TextObject
    {
        #region Constructor

        public TextObject(
            TextType type,
            string text,
            bool? emoji = null,
            bool? verbatim = null
        )
        {
            // Validate parameters.
            Text = string.IsNullOrWhiteSpace(text)
                ? throw new ArgumentNullException(nameof(text))
                : text;

            // Assign values.
            Type = type;
            Emoji = emoji;
            Verbatim = verbatim;
        }

        #endregion

        #region Instance, read-only state

        public string Text { get; }

        public TextType Type { get; }

        public bool? Emoji { get; }

        public bool? Verbatim { get; } 

        #endregion
    }
}
