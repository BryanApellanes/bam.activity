using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has moved               object from origin to               target. If the origin or               target are not specified, either can be determined by context.
    /// </summary>
    public partial class Move : Activity, IMove
    {
        public Move(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally moved a post from List A to List B"",
  ""type"": ""Move"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/posts/1"",
  ""target"": {
    ""type"": ""Collection"",
    ""name"": ""List B""
  },
  ""origin"": {
    ""type"": ""Collection"",
    ""name"": ""List A""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}