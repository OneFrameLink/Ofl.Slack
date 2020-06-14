using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi.Methods.Files
{
    public interface IFilesMethods
    {
        Task<UploadResponse> UploadAsync(
            UploadRequest request,
            CancellationToken cancellationToken
        );
    }
}
