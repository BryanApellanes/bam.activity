using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor dislikes the               object.
    /// </summary>
    public partial class Dislike : Activity, IDislike
    {
        public Dislike(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally disliked a post"",
  ""type"": ""Dislike"",
  ""actor"": ""http://sally.example.org"",
  ""object"": ""http://example.org/posts/1""
}");
            this.EndCtorInit(idHost);
        }


    }
}