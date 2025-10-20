using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a service of any kind.
    /// </summary>
    public partial class Service : Object, IService
    {
        public Service(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Service"",
  ""name"": ""Acme Web Service""
}");
            this.EndCtorInit(idHost);
        }


    }
}