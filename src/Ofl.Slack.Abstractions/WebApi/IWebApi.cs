using Ofl.Slack.WebApi.Methods.Chat;
using Ofl.Slack.WebApi.Methods.Files;

namespace Ofl.Slack.WebApi
{
    public interface IWebApi
    {
        public IChatMethods Chat { get; }

        public IFilesMethods Files { get; }
    }
}
