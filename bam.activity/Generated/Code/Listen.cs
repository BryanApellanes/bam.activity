using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has listened to the               object.
    /// </summary>
    public partial class Listen : Activity, IListen
    {
        public Listen(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally listened to a piece of music"",
  ""type"": ""Listen"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/music.mp3""
}");
            this.EndCtorInit(idHost);
        }


    }
}