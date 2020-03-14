using System;
using System.Collections.Generic;
using System.Text;

namespace Ofl.Slack.WebApi
{
    public class Response
    {
        public bool Ok { get; set; }

        public string? Error { get; set; }

        public string? Warning { get; set; }
    }
}
