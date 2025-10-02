using System;

namespace Bam.Activity.Vocabulary
{
    public class Collection : Object, ICollection
    {
        public Collection(IdHost idHost) : base(idHost)
        {
            this.InitProperty("totalItems", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("current", null, true, "CollectionPage", "Link");
            this.InitProperty("first", null, true, "CollectionPage", "Link");
            this.InitProperty("last", null, true, "CollectionPage", "Link");
            this.InitProperty("items", null, false, "Object", "Link", "Object", "Link");
        }

        public Range<ulong>? TotalItems
        {
            get
            {
                return Property("totalItems") as Range<ulong>;
            }
            set
            {
                Property("totalItems", value);
            }
        }
    
        public Range<CollectionPage, Link>? Current
        {
            get
            {
                return Property("current") as Range<CollectionPage, Link>;
            }
            set
            {
                Property("current", value);
            }
        }
    
        public Range<CollectionPage, Link>? First
        {
            get
            {
                return Property("first") as Range<CollectionPage, Link>;
            }
            set
            {
                Property("first", value);
            }
        }
    
        public Range<CollectionPage, Link>? Last
        {
            get
            {
                return Property("last") as Range<CollectionPage, Link>;
            }
            set
            {
                Property("last", value);
            }
        }
    
        public Range<Object, Link>? Items
        {
            get
            {
                return Property("items") as Range<Object, Link>;
            }
            set
            {
                Property("items", value);
            }
        }
    

    }
}