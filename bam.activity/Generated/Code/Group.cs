using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a formal or informal collective of Actors.
    /// </summary>
    public partial class Group : Object, IGroup
    {
        public Group(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Group"",
  ""name"": ""Big Beards of Austin""
}");
            this.EndCtorInit(idHost);
        }


    }
}