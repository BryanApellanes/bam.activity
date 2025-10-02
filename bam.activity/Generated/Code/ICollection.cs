using System;

namespace Bam.Activity.Vocabulary
{
    public interface ICollection
    {

        public Range<ulong>? TotalItems { get; set; }
        public Range<CollectionPage, Link>? Current { get; set; }
        public Range<CollectionPage, Link>? First { get; set; }
        public Range<CollectionPage, Link>? Last { get; set; }
        public Range<Object, Link>? Items { get; set; }

    }
}