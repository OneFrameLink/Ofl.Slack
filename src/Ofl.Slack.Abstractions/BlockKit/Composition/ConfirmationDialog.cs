using System;
using System.Collections.Generic;
using System.Text;

namespace Ofl.Slack.BlockKit.Composition
{
    public class ConfirmationDialog
    {
        #region Constructor

        public ConfirmationDialog(
            TextObject title,
            TextObject text,
            TextObject confirm,
            TextObject deny
        )
        {
            // Validate parameters.
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Confirm = confirm ?? throw new ArgumentNullException(nameof(confirm));
            Deny = deny ?? throw new ArgumentNullException(nameof(deny));
        }

        #endregion

        #region Instance, read-only state

        public TextObject Title { get; }

        public TextObject Text { get; }

        public TextObject Confirm { get; }

        public TextObject Deny { get; }

        #endregion
    }
}
