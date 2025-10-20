using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A Collection is a subtype of               Object that represents ordered or unordered sets of Object or Link instances.                                         Refer to the               Activity Streams 2.0 Core specification for a complete description of the               Collection type.
    /// </summary>
    public partial class Collection : Object, ICollection
    {
        public Collection(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("totalItems", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("current", null, true, "CollectionPage", "Link");
            this.InitProperty("first", null, true, "CollectionPage", "Link");
            this.InitProperty("last", null, true, "CollectionPage", "Link");
            this.InitProperty("items", null, false, "Object", "Link", "Object", "Link");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally's notes"",
  ""type"": ""Collection"",
  ""totalItems"": 2,
  ""items"": [
    {
      ""type"": ""Note"",
      ""name"": ""A Simple Note""
    },
    {
      ""type"": ""Note"",
      ""name"": ""Another Simple Note""
    }
  ]
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// A non-negative integer specifying the total number of objects contained by the logical view of the collection. This number might not reflect the actual number of items serialized within the Collection object instance.
        /// </summary>
        public ulong? TotalItems
        {
            get
            {
                return Property<ulong>("totalItems");
            }
            set
            {
                Property("totalItems", value);
            }
        }

        /// <summary>
        /// In a paged Collection, indicates the page that contains the most recently updated member items.
        /// </summary>
        public Range<CollectionPage, Link>? Current
        {
            get
            {
                return Property<Range<CollectionPage, Link>>("current");
            }
            set
            {
                Property("current", value);
            }
        }

        /// <summary>
        /// In a paged Collection, indicates the furthest preceeding page of items in the collection.
        /// </summary>
        public Range<CollectionPage, Link>? First
        {
            get
            {
                return Property<Range<CollectionPage, Link>>("first");
            }
            set
            {
                Property("first", value);
            }
        }

        /// <summary>
        /// In a paged Collection, indicates the furthest proceeding page of the collection.
        /// </summary>
        public Range<CollectionPage, Link>? Last
        {
            get
            {
                return Property<Range<CollectionPage, Link>>("last");
            }
            set
            {
                Property("last", value);
            }
        }

        /// <summary>
        /// Identifies the items contained in a collection. The items might be ordered or unordered.
        /// </summary>
        public Range<Object, Link>? Items
        {
            get
            {
                return Property<Range<Object, Link>>("items");
            }
            set
            {
                Property("items", value);
            }
        }


    }
}