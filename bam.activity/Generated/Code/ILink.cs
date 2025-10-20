using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface ILink
    {

        public string? Href { get; set; }
        public string? Rel { get; set; }
        public Object? MediaType { get; set; }
        public string? Name { get; set; }
        public string? Hreflang { get; set; }
        public ulong? Height { get; set; }
        public ulong? Width { get; set; }
        public Range<Link, Object>? Preview { get; set; }

    }
}