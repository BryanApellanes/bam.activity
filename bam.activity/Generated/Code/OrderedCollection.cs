using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A subtype of Collection in which members of the logical collection are assumed to always be strictly ordered.
    /// </summary>
    public partial class OrderedCollection : Collection, IOrderedCollection
    {
        public OrderedCollection(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally's notes"",
  ""type"": ""OrderedCollection"",
  ""totalItems"": 2,
  ""orderedItems"": [
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


    }
}