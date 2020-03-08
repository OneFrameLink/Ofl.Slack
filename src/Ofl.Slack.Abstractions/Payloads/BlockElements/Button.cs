using Ofl.Slack.Payloads.Composition;
using System;

namespace Ofl.Slack.Payloads.BlockElements
{
    public class Button : ActionElement
    {
        #region Constructor

        public Button(
            TextObject text,
            string actionId,
            string? url = null,
            string? value = null,
            string? style = null,
            ConfirmationDialog? confirm = null
        ) : base(actionId)
        {
            // Validate parameters.
            Text = text ?? throw new ArgumentNullException(nameof(text));

            // Assign values.
            Url = url;
            Value = value;
            Style = style;
            Confirm = confirm;
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "button";

        public TextObject Text { get; }

        public string? Url { get; }

        public string? Value { get; }

        public string? Style { get; }

        public ConfirmationDialog? Confirm { get; }

        #endregion
    }
}
