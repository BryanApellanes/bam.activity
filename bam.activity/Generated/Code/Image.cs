using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// An image document of any kind
    /// </summary>
    public partial class Image : Document, IImage
    {
        public Image(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Image"",
  ""name"": ""Cat Jumping on Wagon"",
  ""url"": [
    {
      ""type"": ""Link"",
      ""href"": ""http://example.org/image.jpeg"",
      ""mediaType"": ""image/jpeg""
    },
    {
      ""type"": ""Link"",
      ""href"": ""http://example.org/image.png"",
      ""mediaType"": ""image/png""
    }
  ]
}");
            this.EndCtorInit(idHost);
        }


    }
}