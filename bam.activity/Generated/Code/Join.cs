using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has joined the               object. The target and               origin typically have no defined meaning.
    /// </summary>
    public partial class Join : Activity, IJoin
    {
        public Join(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally joined a group"",
  ""type"": ""Join"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Group"",
    ""name"": ""A Simple Group""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}