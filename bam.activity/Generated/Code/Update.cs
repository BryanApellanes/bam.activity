using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has updated the                 object. Note, however, that this vocabulary does not define a mechanism for describing the actual set of modifications made to object.                                               The target and                 origin typically have no defined meaning.
    /// </summary>
    public partial class Update : Activity, IUpdate
    {
        public Update(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally updated her note"",
  ""type"": ""Update"",
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