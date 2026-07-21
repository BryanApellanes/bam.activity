using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface ICollection
    {

        public ulong? TotalItems { get; set; }
        public Range<CollectionPage, Link>? Current { get; set; }
        public Range<CollectionPage, Link>? First { get; set; }
        public Range<CollectionPage, Link>? Last { get; set; }
        public Range<Object, Link>? Items { get; set; }

    }
}