using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A specialization of Reject in which the rejection is considered tentative.
    /// </summary>
    public partial class TentativeReject : Reject, ITentativeReject
    {
        public TentativeReject(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally tentatively rejected an invitation to a party"",
  ""type"": ""TentativeReject"",
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