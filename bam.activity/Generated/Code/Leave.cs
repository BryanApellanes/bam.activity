using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has left the               object. The target and               origin typically have no meaning.
    /// </summary>
    public partial class Leave : Activity, ILeave
    {
        public Leave(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally left work"",
  ""type"": ""Leave"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Place"",
    ""name"": ""Work""
  }
}");
            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally left a group"",
  ""type"": ""Leave"",
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