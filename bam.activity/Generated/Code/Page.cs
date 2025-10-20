using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a Web Page.
    /// </summary>
    public partial class Page : Document, IPage
    {
        public Page(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Page"",
  ""name"": ""Omaha Weather Report"",
  ""url"": ""http://example.org/weather-in-omaha.html""
}");
            this.EndCtorInit(idHost);
        }


    }
}