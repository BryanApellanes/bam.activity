using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has deleted the               object. If specified, the origin indicates the context from which the object was deleted.
    /// </summary>
    public partial class Delete : Activity, IDelete
    {
        public Delete(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally deleted a note"",
  ""type"": ""Delete"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/notes/1"",
  ""origin"": {
    ""type"": ""Collection"",
    ""name"": ""Sally's Notes""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}