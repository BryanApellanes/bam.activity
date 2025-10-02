using System;

namespace Bam.Activity.Vocabulary
{
    public interface ICollectionPage
    {

        public Range<Link, Collection>? PartOf { get; set; }
        public Range<CollectionPage, Link>? Next { get; set; }
        public Range<CollectionPage, Link>? Prev { get; set; }

    }
}