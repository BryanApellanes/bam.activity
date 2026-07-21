using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is traveling to               target from origin. Travel is an IntransitiveObject whose actor specifies the direct object. If the target or               origin are not specified, either can be determined by context.
    /// </summary>
    public partial class Travel : IntransitiveActivity, ITravel
    {
        public Travel(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally went home from work"",
  ""type"": ""Travel"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""target"": {
    ""type"": ""Place"",
    ""name"": ""Home""
  },
  ""origin"": {
    ""type"": ""Place"",
    ""name"": ""Work""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}