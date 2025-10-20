using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a video document of any kind.
    /// </summary>
    public partial class Video : Document, IVideo
    {
        public Video(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Video"",
  ""name"": ""Puppy Plays With Ball"",
  ""url"": ""http://example.org/video.mkv"",
  ""duration"": ""PT2H""
}");
            this.EndCtorInit(idHost);
        }


    }
}