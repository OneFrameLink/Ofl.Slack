using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi.Methods.Chat
{
    public interface IChatMethods
    {
        Task<PostMessageResponse> PostMessageAsync(PostMessageRequest request, CancellationToken cancellationToken = default);
    }
}
