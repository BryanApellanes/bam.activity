using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A specialization of Accept indicating that the acceptance is tentative.
    /// </summary>
    public partial class TentativeAccept : Accept, ITentativeAccept
    {
        public TentativeAccept(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally tentatively accepted an invitation to a party"",
  ""type"": ""TentativeAccept"",
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