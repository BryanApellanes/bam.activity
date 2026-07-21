using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents an individual person.
    /// </summary>
    public partial class Person : Object, IPerson
    {
        public Person(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Person"",
  ""name"": ""Sally Smith""
}");
            this.EndCtorInit(idHost);
        }


    }
}