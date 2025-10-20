using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a document of any kind.
    /// </summary>
    public partial class Document : Object, IDocument
    {
        public Document(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Document"",
  ""name"": ""4Q Sales Forecast"",
  ""url"": ""http://example.org/4q-sales-forecast.pdf""
}");
            this.EndCtorInit(idHost);
        }


    }
}