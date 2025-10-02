using System;

namespace Bam.Activity.Vocabulary
{
    public interface IOrderedCollectionPage
    {

        public Range<ulong>? StartIndex { get; set; }
        public Range<Link, Collection>? PartOf { get; set; }
        public Range<CollectionPage, Link>? Next { get; set; }
        public Range<CollectionPage, Link>? Prev { get; set; }

    }
}