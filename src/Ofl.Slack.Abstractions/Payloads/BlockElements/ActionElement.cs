using System;

namespace Ofl.Slack.Payloads.BlockElements
{
    public abstract class ActionElement : BlockElement
    {
        #region Constructor

        protected ActionElement(
            string actionId
        )
        {
            // Validate parameters.
            ActionId = string.IsNullOrWhiteSpace(actionId)
                ? throw new ArgumentNullException(nameof(actionId))
                : actionId;
        }

        #endregion

        #region Instance, read-only state

        public string ActionId { get; }

        #endregion
    }
}
