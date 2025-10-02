using System;

namespace Bam.Activity.Vocabulary
{
    public class CollectionPage : Collection, ICollectionPage
    {
        public CollectionPage(IdHost idHost) : base(idHost)
        {
            this.InitProperty("partOf", null, true, "Link", "Collection");
            this.InitProperty("next", null, true, "CollectionPage", "Link");
            this.InitProperty("prev", null, true, "CollectionPage", "Link");
        }

        public Range<Link, Collection>? PartOf
        {
            get
            {
                return Property("partOf") as Range<Link, Collection>;
            }
            set
            {
                Property("partOf", value);
            }
        }
    
        public Range<CollectionPage, Link>? Next
        {
            get
            {
                return Property("next") as Range<CollectionPage, Link>;
            }
            set
            {
                Property("next", value);
            }
        }
    
        public Range<CollectionPage, Link>? Prev
        {
            get
            {
                return Property("prev") as Range<CollectionPage, Link>;
            }
            set
            {
                Property("prev", value);
            }
        }
    

    }
}