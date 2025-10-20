using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has viewed the object.
    /// </summary>
    public partial class View : Activity, IView
    {
        public View(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally read an article"",
  ""type"": ""View"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Article"",
    ""name"": ""What You Should Know About Activity Streams""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}