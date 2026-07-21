using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is 'following' the               object. Following is defined in the sense typically used within Social systems in which the actor is interested in any activity performed by or on the object. The               target and origin typically have no defined meaning.
    /// </summary>
    public partial class Follow : Activity, IFollow
    {
        public Follow(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally followed John"",
  ""type"": ""Follow"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Person"",
    ""name"": ""John""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}