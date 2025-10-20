using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is blocking the               object. Blocking is a stronger form of               Ignore. The typical use is to support social systems that allow one user to block activities or content of other users. The target and origin typically have no defined meaning.
    /// </summary>
    public partial class Block : Ignore, IBlock
    {
        public Block(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally blocked Joe"",
  ""type"": ""Block"",
  ""actor"": ""http://sally.example.org"",
  ""object"": ""http://joe.example.org""
}");
            this.EndCtorInit(idHost);
        }


    }
}