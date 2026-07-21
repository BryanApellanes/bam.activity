using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// An IntransitiveActivity that indicates that the actor has arrived at the location. The origin can be used to identify the context from which the actor originated. The target typically has no defined meaning.
    /// </summary>
    public partial class Arrive : IntransitiveActivity, IArrive
    {
        public Arrive(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally arrived at work"",
  ""type"": ""Arrive"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""location"": {
    ""type"": ""Place"",
    ""name"": ""Work""
  },
  ""origin"": {
    ""type"": ""Place"",
    ""name"": ""Home""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}