using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Describes a software application.
    /// </summary>
    public partial class Application : Object, IApplication
    {
        public Application(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Application"",
  ""name"": ""Exampletron 3000""
}");
            this.EndCtorInit(idHost);
        }


    }
}