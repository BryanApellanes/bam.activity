using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents any kind of event.
    /// </summary>
    public partial class Event : Object, IEvent
    {
        public Event(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Event"",
  ""name"": ""Going-Away Party for Jim"",
  ""startTime"": ""2014-12-31T23:00:00-08:00"",
  ""endTime"": ""2015-01-01T06:00:00-08:00""
}");
            this.EndCtorInit(idHost);
        }


    }
}