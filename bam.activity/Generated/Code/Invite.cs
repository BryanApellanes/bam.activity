using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A specialization of Offer in which the               actor is extending an invitation for the               object to the target.
    /// </summary>
    public partial class Invite : Offer, IInvite
    {
        public Invite(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally invited John and Lisa to a party"",
  ""type"": ""Invite"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Event"",
    ""name"": ""A Party""
  },
  ""target"": [
    {
      ""type"": ""Person"",
      ""name"": ""John""
    },
    {
      ""type"": ""Person"",
      ""name"": ""Lisa""
    }
  ]
}");
            this.EndCtorInit(idHost);
        }


    }
}