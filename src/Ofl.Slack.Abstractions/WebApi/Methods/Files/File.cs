using System.Collections.Generic;

namespace Ofl.Slack.WebApi.Methods.Files
{
    public class File
    {
        public string Id { get; set; } = null!;

        public long Created { get; set; }

        public long? Updated { get; set; }

        public string Name { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Mimetype { get; set; } = null!;

        public string Filetype { get; set; } = null!;

        public string PrettyType { get; set; } = null!;

        public string User { get; set; } = null!;

        public bool Editable { get; set; }

        public string? EditLink { get; set; }

        public long Size { get; set; }

        public string Mode { get; set; } = null!;

        public bool IsExternal { get; set; }

        public string ExternalType { get; set; } = null!;

        public bool IsPublic { get; set; }

        public bool PublicUrlShared { get; set; }

        public bool DisplayAsBot { get; set; }

        public string Username { get; set; } = null!;

        public string UrlPrivate { get; set; } = null!;

        public string UrlPrivateDownload { get; set; } = null!;

        public string? Thumb64 { get; set; }

        public string? Thumb80 { get; set; }

        public string? Thumb360 { get; set; }

        public string? Thumb480 { get; set; }

        public string? Thumb720 { get; set; }

        public string? Thumb960 { get; set; }

        public string? Thumb1024 { get; set; }

        public int? Thumb360W { get; set; }

        public int? Thumb360H { get; set; }

        public string? Thumb160 { get; set; } = null!;

        public string? Thumb360Gif { get; set; } = null!;

        public bool? ImageExifRotation { get; set; }

        public int? OriginalW { get; set; }

        public int? OriginalH { get; set; }

        public string? DeanimateGif { get; set; }

        public string? Pjpeg { get; set; }

        public string Permalink { get; set; } = null!;

        public string PermalinkPublic { get; set; } = null!;

        public int CommentsCount { get; set; }

        public bool? IsStarred { get; set; }

        public IReadOnlyCollection<string> Channels { get; set; } = null!;

        public IReadOnlyCollection<string> Groups { get; set; } = null!;

        public IReadOnlyCollection<string> Ims { get; set; } = null!;

        public bool HasRichPreview { get; set; }

        public string Preview { get; set; } = null!;

        public int? Lines { get; set; }

        public int? LinesMore { get; set; }

        public int? NumStars { get; set; }

        public IReadOnlyCollection<string>? PinnedTo { get; set; }

        public string? InitialComment { get; set; }
    }
}
