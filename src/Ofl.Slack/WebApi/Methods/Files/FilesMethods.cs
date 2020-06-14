using Ofl.Net.Http.ApiClient.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Slack.WebApi.Methods.Files
{
    internal class FilesMethods : Methods, IFilesMethods
    {
        #region Constructor

        public FilesMethods(WebApi webApi) : base(webApi)
        { }

        #endregion

        #region Read-only state

        private static readonly MediaTypeHeaderValue MultipartFormDataHeaderValue = MediaTypeHeaderValue.Parse("multipart/form-data");
            
        #endregion

        #region IChatMethods implementation

        public async Task<UploadResponse> UploadAsync(
            UploadRequest request,
            CancellationToken cancellationToken
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Create the content.
            using var content = new MultipartFormDataContent();

            // Add parameters.
            if (request.Channels.Any())
                content.AddString("channels", string.Join(",", request.Channels));

            // Add the rest.
            content.Add(request.File, "file", request.Filename);
            content.AddString("filename", request.Filename);
            content.AddString("filetype", request.Filetype);
            content.AddString("initial_comment", request.InitialComment);
            content.AddString("thread_ts", request.ThreadTS);
            content.AddString("title", request.Title);

            // On the file content, set the multipart form data header.
            request.File.Headers.ContentType = MultipartFormDataHeaderValue;

            // Post the content.
            using HttpResponseMessage response = await WebApi.HttpClient
                .PostAsync(WebApi.ApiUrlPrefix + "files.upload", content, cancellationToken)
                .ConfigureAwait(false);

            // Serialize the response.
            return await response
                .ToObjectAsync<UploadResponse>(WebApi.JsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
