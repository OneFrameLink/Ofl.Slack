namespace Ofl.Slack.WebApi.Methods.Chat
{
    public class PostMessageResponse : Response
    {
        public string Channel { get; set; } = null!;

        public string Ts { get; set; } = null!;
    }
}
