using Ofl.Slack.BlockKit.BlockElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ofl.Slack.BlockKit.Blocks
{
    public class Context : Block
    {
        #region Constructor

        public Context(
            IEnumerable<BlockElement> elements,
            string? blockId = null
        ) : base(blockId)
        {
            // Validate parameters.
            Elements = new ReadOnlyCollection<BlockElement>(
                elements?.ToList() ?? throw new ArgumentNullException(nameof(elements))
            );
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "context";

        public IReadOnlyCollection<BlockElement> Elements { get; }

        #endregion
    }
}
