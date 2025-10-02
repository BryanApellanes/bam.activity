using System;

namespace Bam.Activity.Vocabulary
{
    public interface ILink
    {

        public Range<string>? Href { get; set; }
        public Range<string>? Rel { get; set; }
        public Object? MediaType { get; set; }
        public Range<string>? Name { get; set; }
        public Range<string>? Hreflang { get; set; }
        public Range<ulong>? Height { get; set; }
        public Range<ulong>? Width { get; set; }
        public Range<Link, Object>? Preview { get; set; }

    }
}