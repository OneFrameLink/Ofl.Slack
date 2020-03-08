using Ofl.Slack.Payloads.BlockElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ofl.Slack.Payloads.Blocks
{
    public class Actions : Block
    {
        #region Constructor

        public Actions(
            IEnumerable<BlockElement> elements,
            string? blockId
        ) : base(blockId)
        {
            // Validate parameters.
            Elements = new ReadOnlyCollection<BlockElement>(
                elements?.ToList() ?? throw new ArgumentNullException(nameof(elements))
            );
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "actions";

        public IReadOnlyCollection<BlockElement> Elements { get; }

        #endregion
    }
}
