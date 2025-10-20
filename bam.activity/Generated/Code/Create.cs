using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has created the                 object.
    /// </summary>
    public partial class Create : Activity, ICreate
    {
        public Create(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally created a note"",
  ""type"": ""Create"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Note"",
    ""name"": ""A Simple Note"",
    ""content"": ""This is a simple note""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}