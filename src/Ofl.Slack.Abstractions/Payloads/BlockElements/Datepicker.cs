using Ofl.Slack.Payloads.Composition;
using System;

namespace Ofl.Slack.Payloads.BlockElements
{
    public class Datepicker : ActionElement
    {
        #region Constructor

        public Datepicker(
            string actionId,
            TextObject? placeholder = null,
            DateTime? initialDate = null,
            ConfirmationDialog? confirm = null
        ) : base(actionId)
        {
            // Assign values.
            Placeholder = placeholder;
            InitialDate = initialDate;
            Confirm = confirm;
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "datepicker";

        public TextObject? Placeholder { get; }

        public DateTime? InitialDate { get; }

        public ConfirmationDialog? Confirm { get; }

        #endregion
    }
}
