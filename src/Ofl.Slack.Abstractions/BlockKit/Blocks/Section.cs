using Ofl.Slack.BlockKit.BlockElements;
using Ofl.Slack.BlockKit.Blocks;
using Ofl.Slack.BlockKit.Composition;
using System;
using System.Collections.Generic;

namespace Ofl.BlockKit.Payloads
{
    public class Section : Block
    {
        #region Constructor

        public Section(
            TextObject text,
            string? blockId = null,
            IReadOnlyCollection<TextObject>? fields = null,
            BlockElement? accessory = null
        ): base(blockId)
        {
            // Validate parameters.
            Text = text ?? throw new ArgumentNullException(nameof(text));

            // Assign values.
            Fields = fields;
            Accessory = accessory;
        }

        #endregion

        #region Instance, read-only state

        public override string Type => "section";

        public TextObject Text { get; }

        public IReadOnlyCollection<TextObject>? Fields { get; }

        public BlockElement? Accessory { get; }

        #endregion
    }
}
