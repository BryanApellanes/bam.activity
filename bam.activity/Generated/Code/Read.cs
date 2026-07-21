using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has read the               object.
    /// </summary>
    public partial class Read : Activity, IRead
    {
        public Read(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally read a blog post"",
  ""type"": ""Read"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/posts/1""
}");
            this.EndCtorInit(idHost);
        }


    }
}