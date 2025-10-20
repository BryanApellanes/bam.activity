using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is offering the               object. If specified, the target indicates the entity to which the object is being offered.
    /// </summary>
    public partial class Offer : Activity, IOffer
    {
        public Offer(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally offered 50% off to Lewis"",
  ""type"": ""Offer"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""http://www.types.example/ProductOffer"",
    ""name"": ""50% Off!""
  },
  ""target"": {
    ""type"": ""Person"",
    ""name"": ""Lewis""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}