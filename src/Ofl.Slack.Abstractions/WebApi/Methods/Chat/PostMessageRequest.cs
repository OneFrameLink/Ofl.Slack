using Ofl.Slack.BlockKit.Blocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ofl.Slack.WebApi.Methods.Chat
{
    public class PostMessageRequest
    {
        #region Constructor

        public PostMessageRequest(
            string channel,
            string? text = null,
            IEnumerable<Block>? blocks = null,
            string? iconEmoji = null,
            string? iconUrl = null,
            bool? linkNames = null,
            bool? mrkdwn = null,
            string? parse = null,
            bool? replyBroadcast = null,
            string? threadTs = null,
            bool? unfurlLinks = null,
            bool? unfurlMedia = null,
            string? username = null
        )
        {
            // Validate parameters.
            Channel = string.IsNullOrWhiteSpace(channel)
                ? throw new ArgumentNullException(nameof(channel))
                : channel;

            // Assign values.
            Text = text;
            Blocks = blocks == null
                ? null
                : new ReadOnlyCollection<Block>(blocks.ToList());
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            LinkNames = linkNames;
            Mrkdwn = mrkdwn;
            Parse = parse;
            ReplyBroadcast = replyBroadcast;
            ThreadTs = threadTs;
            UnfurlLinks = unfurlLinks;
            UnfurlMedia = unfurlMedia;
            Username = username;


            // If blocks is null, text must be set.
            if (blocks == null)
            {
                // If text is not set, throw.
                if (string.IsNullOrWhiteSpace(text))
                    throw new ArgumentNullException(nameof(text),
                        $"The {nameof(text)} parameter cannot be null or whitespace when the {nameof(blocks)} parameter is null.");
            }
        }

        #endregion

        #region Instance, read-only state

        public string Channel { get; }

        public string? Text { get; }

        public IReadOnlyCollection<Block>? Blocks { get; }

        public string? IconEmoji { get; }

        public string? IconUrl { get; }

        public bool? LinkNames { get; }

        public bool? Mrkdwn { get; }

        public string? Parse { get; }

        public bool? ReplyBroadcast { get; }

        public string? ThreadTs { get; }

        public bool? UnfurlLinks { get; }

        public bool? UnfurlMedia { get; }

        public string? Username { get; }

        #endregion
    }
}
