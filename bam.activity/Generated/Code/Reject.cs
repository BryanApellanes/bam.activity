using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is rejecting the               object. The target and               origin typically have no defined meaning.
    /// </summary>
    public partial class Reject : Activity, IReject
    {
        public Reject(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally rejected an invitation to a party"",
  ""type"": ""Reject"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Invite"",
    ""actor"": ""http://john.example.org"",
    ""object"": {
      ""type"": ""Event"",
      ""name"": ""Going-Away Party for Jim""
    }
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}