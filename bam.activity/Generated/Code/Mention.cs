using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A specialized Link that represents an @mention.
    /// </summary>
    public partial class Mention : Link, IMention
    {
        public Mention(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Mention of Joe by Carrie in her note"",
  ""type"": ""Mention"",
  ""href"": ""http://example.org/joe"",
  ""name"": ""Joe""
}");
            this.EndCtorInit(idHost);
        }


    }
}