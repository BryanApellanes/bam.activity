using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor likes, recommends or endorses the object. The target and                 origin typically have no defined meaning.
    /// </summary>
    public partial class Like : Activity, ILike
    {
        public Like(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally liked a note"",
  ""type"": ""Like"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/notes/1""
}");
            this.EndCtorInit(idHost);
        }


    }
}