using System.Net.Http;

namespace Ofl.Slack.WebApi.Methods.Files
{
    internal static class MultipartFormDataContentExtensions
    {
        public static void AddString(this MultipartFormDataContent content, string key, string? value)
        {
            // If there is no value, get out.
            if (string.IsNullOrWhiteSpace(value))
                return;

            // Create the string content.
            var stringContent = new StringContent(value);

            // Add.
            content.Add(stringContent, key);
        }
    }
}
