using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Used to represent distinct subsets of items from a               Collection. Refer to the               Activity Streams 2.0 Core for a complete description of the               CollectionPage object.
    /// </summary>
    public partial class CollectionPage : Collection, ICollectionPage
    {
        public CollectionPage(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("partOf", null, true, "Link", "Collection");
            this.InitProperty("next", null, true, "CollectionPage", "Link");
            this.InitProperty("prev", null, true, "CollectionPage", "Link");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Page 1 of Sally's notes"",
  ""type"": ""CollectionPage"",
  ""id"": ""http://example.org/foo?page=1"",
  ""partOf"": ""http://example.org/foo"",
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
        /// Identifies the Collection to which a             CollectionPage objects items belong.
        /// </summary>
        public Range<Link, Collection>? PartOf
        {
            get
            {
                return Property<Range<Link, Collection>>("partOf");
            }
            set
            {
                Property("partOf", value);
            }
        }

        /// <summary>
        /// In a paged Collection, indicates the next page of items.
        /// </summary>
        public Range<CollectionPage, Link>? Next
        {
            get
            {
                return Property<Range<CollectionPage, Link>>("next");
            }
            set
            {
                Property("next", value);
            }
        }

        /// <summary>
        /// In a paged Collection, identifies the previous page of items.
        /// </summary>
        public Range<CollectionPage, Link>? Prev
        {
            get
            {
                return Property<Range<CollectionPage, Link>>("prev");
            }
            set
            {
                Property("prev", value);
            }
        }


    }
}