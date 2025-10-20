using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is ignoring the               object. The target and               origin typically have no defined meaning.
    /// </summary>
    public partial class Ignore : Activity, IIgnore
    {
        public Ignore(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally ignored a note"",
  ""type"": ""Ignore"",
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