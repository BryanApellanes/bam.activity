using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is calling the target's attention the object.                                               The origin typically has no defined meaning.
    /// </summary>
    public partial class Announce : Activity, IAnnounce
    {
        public Announce(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally announced that she had arrived at work"",
  ""type"": ""Announce"",
  ""actor"": {
    ""type"": ""Person"",
    ""id"": ""http://sally.example.org"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Arrive"",
    ""actor"": ""http://sally.example.org"",
    ""location"": {
      ""type"": ""Place"",
      ""name"": ""Work""
    }
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}