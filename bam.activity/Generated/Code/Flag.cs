using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is 'flagging' the               object. Flagging is defined in the sense common to many social platforms as reporting content as being inappropriate for any number of reasons.
    /// </summary>
    public partial class Flag : Activity, IFlag
    {
        public Flag(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally flagged an inappropriate note"",
  ""type"": ""Flag"",
  ""actor"": ""http://sally.example.org"",
  ""object"": {
    ""type"": ""Note"",
    ""content"": ""An inappropriate note""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}