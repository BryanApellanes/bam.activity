using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface ICollectionPage
    {

        public Range<Link, Collection>? PartOf { get; set; }
        public Range<CollectionPage, Link>? Next { get; set; }
        public Range<CollectionPage, Link>? Prev { get; set; }

    }
}