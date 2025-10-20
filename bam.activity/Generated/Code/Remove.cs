using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Indicates that the actor is removing the               object. If specified, the origin indicates the context from which the object is being removed.
    /// </summary>
    public partial class Remove : Activity, IRemove
    {
        public Remove(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally removed a note from her notes folder"",
  ""type"": ""Remove"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": ""http://example.org/notes/1"",
  ""target"": {
    ""type"": ""Collection"",
    ""name"": ""Notes Folder""
  }
}");
            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""The moderator removed Sally from a group"",
  ""type"": ""Remove"",
  ""actor"": {
    ""type"": ""http://example.org/Role"",
    ""name"": ""The Moderator""
  },
  ""object"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""origin"": {
    ""type"": ""Group"",
    ""name"": ""A Simple Group""
  }
}");
            this.EndCtorInit(idHost);
        }


    }
}