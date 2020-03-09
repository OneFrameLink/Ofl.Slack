using Ofl.Slack.BlockKit.Blocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ofl.Slack.Messaging.Payload
{
    public class MessagePayload
    {
        #region Constructor

        public MessagePayload(
            string? text = null,
            IEnumerable<Block>? blocks = null,
            string? threadTs = null,
            bool? mrkdwn = null
        )
        {
            // Assign values.
            Text = text;
            Blocks = blocks == null 
                ? null 
                : new ReadOnlyCollection<Block>(blocks.ToList());
            ThreadTs = threadTs;
            Mrkdwn = mrkdwn;

            // Validate parameters.
            if (string.IsNullOrWhiteSpace(text))
            {
                // If the blocks are null throw.
                if (blocks == null)
                    throw new ArgumentNullException(nameof(blocks),
                        $"The {nameof(blocks)} parameter cannot be null when the {nameof(text)} parameter is not set.");
            }
        }

        #endregion

        #region Instance, read-only state

        public string? Text { get; }

        public IReadOnlyCollection<Block>? Blocks { get; }

        public string? ThreadTs { get; }

        public bool? Mrkdwn { get; }

        #endregion
    }
}
