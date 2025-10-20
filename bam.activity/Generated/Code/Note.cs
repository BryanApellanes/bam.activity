using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a short written work typically less than a single paragraph in length.
    /// </summary>
    public partial class Note : Object, INote
    {
        public Note(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Note"",
  ""name"": ""A Word of Warning"",
  ""content"": ""Looks like it is going to rain today. Bring an umbrella!""
}");
            this.EndCtorInit(idHost);
        }


    }
}