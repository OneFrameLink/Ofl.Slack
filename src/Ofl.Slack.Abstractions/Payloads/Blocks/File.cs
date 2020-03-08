using System;
using System.Collections.Generic;
using System.Text;

namespace Ofl.Slack.Payloads.Blocks
{
    public class File : Block
    {
        #region Constructor

        public File(
            string externalId,
            string? blockId = null
        ) : base(blockId)
        {
            // Validate parameters.
            ExternalId = string.IsNullOrWhiteSpace(externalId)
                ? throw new ArgumentNullException(nameof(externalId))
                : externalId;
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "file";

        public string ExternalId { get; }

        public string Source { get; } = "remote";

        #endregion
    }
}
