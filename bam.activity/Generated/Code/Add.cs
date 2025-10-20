using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor has added the               object to the target. If the               target property is not explicitly specified, the target would need to be determined implicitly by context. The               origin can be used to identify the context from which the object originated.
    /// </summary>
    public partial class Add : Activity, IAdd
    {
        public Add(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally added an object"",
  ""type"": ""Add"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/abc""
}");
            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally added a picture of her cat to her cat picture collection"",
  ""type"": ""Add"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Image"",
    ""name"": ""A picture of my cat"",
    ""url"": ""http://example.org/img/cat.png""
  },
  ""origin"": {
    ""type"": ""Collection"",
    ""name"": ""Camera Roll""
  },
  ""target"": {
    ""type"": ""Collection"",
    ""name"": ""My Cat Pictures""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}