using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Instances of IntransitiveActivity are a subtype of             Activity representing intransitive actions. The             object property is therefore inappropriate for these activities.
    /// </summary>
    public partial class IntransitiveActivity : Activity, IIntransitiveActivity
    {
        public IntransitiveActivity(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Travel"",
  ""summary"": ""Sally went to work"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""target"": {
    ""type"": ""Place"",
    ""name"": ""Work""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}