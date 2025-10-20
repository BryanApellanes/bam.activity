using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents any kind of multi-paragraph written work.
    /// </summary>
    public partial class Article : Object, IArticle
    {
        public Article(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Article"",
  ""name"": ""What a Crazy Day I Had"",
  ""content"": ""<div>... you will never believe ...</div>"",
  ""attributedTo"": ""http://sally.example.org""
}");
            this.EndCtorInit(idHost);
        }


    }
}