using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is undoing the                 object. In most cases, the object will be an Activity describing some previously performed action (for instance, a person may have previously 'liked' an article but, for whatever reason, might choose to undo that like at some later point in time).                                               The target and origin typically have no defined meaning.
    /// </summary>
    public partial class Undo : Activity, IUndo
    {
        public Undo(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally retracted her offer to John"",
  ""type"": ""Undo"",
  ""actor"": ""http://sally.example.org"",
  ""object"": {
    ""type"": ""Offer"",
    ""actor"": ""http://sally.example.org"",
    ""object"": ""http://example.org/posts/1"",
    ""target"": ""http://john.example.org""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}