using System;
using System.Collections.Generic;
using System.Text;

namespace Ofl.Slack.Payloads
{
    public abstract class Block
    {
        #region Constructor

        protected Block(string? blockId)
        {
            // Assign values.
            BlockId = blockId;
        }

        #endregion

        #region Instance, read-only state

        public abstract string Type { get; }

        public string? BlockId { get; set; }

        #endregion
    }
}
