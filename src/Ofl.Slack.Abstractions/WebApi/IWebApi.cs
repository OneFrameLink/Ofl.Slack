using Ofl.Slack.WebApi.Methods.Chat;

namespace Ofl.Slack.WebApi
{
    public interface IWebApi
    {
        public IChatMethods Chat { get; }
    }
}
