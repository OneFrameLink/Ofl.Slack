using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Ofl.Slack.WebApi.Methods.Files
{
    public class UploadRequest
    {
        #region Constructor

        public UploadRequest(
            HttpContent file,
            string filename,
            IEnumerable<string>? channels = null,
            string? filetype = null,
            string? initialComment = null,
            string? threadTs = null,
            string? title = null
        )
        {
            // Validate parameters.
            File = file ?? throw new ArgumentNullException(nameof(file));
            Filename = string.IsNullOrWhiteSpace(filename)
                ? throw new ArgumentNullException(nameof(filename))
                : filename;

            // Assign values.
            Channels = channels ?? Enumerable.Empty<string>();
            Filetype = filetype;
            InitialComment = initialComment;
            ThreadTS = threadTs;
            Title = title;
        }

        #endregion

        #region Instance, read-only state

        public HttpContent File { get; }

        public IEnumerable<string> Channels { get; }

        public string? Filename { get; }

        public string? Filetype { get; }

        public string? InitialComment { get; }

        public string? ThreadTS { get; }

        public string? Title { get; }

        #endregion
    }
}
