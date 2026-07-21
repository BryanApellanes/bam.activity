using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents an audio document of any kind.
    /// </summary>
    public partial class Audio : Document, IAudio
    {
        public Audio(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Audio"",
  ""name"": ""Interview With A Famous Technologist"",
  ""url"": {
    ""type"": ""Link"",
    ""href"": ""http://example.org/podcast.mp3"",
    ""mediaType"": ""audio/mp3""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}