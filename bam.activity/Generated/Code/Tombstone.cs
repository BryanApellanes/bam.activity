using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A Tombstone represents a content object that has been deleted. It can be used in Collections to signify that there used to be an object at this position, but it has been deleted.
    /// </summary>
    public partial class Tombstone : Object, ITombstone
    {
        public Tombstone(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("formerType", null, false, "Object");
            this.InitProperty("deleted", null, true, "xsd:dateTime");

            this.Example(@"{
  ""type"": ""OrderedCollection"",
  ""totalItems"": 3,
  ""name"": ""Vacation photos 2016"",
  ""orderedItems"": [
    {
      ""type"": ""Image"",
      ""id"": ""http://image.example/1""
    },
    {
      ""type"": ""Tombstone"",
      ""formerType"": ""Image"",
      ""id"": ""http://image.example/2"",
      ""deleted"": ""2016-03-17T00:00:00Z""
    },
    {
      ""type"": ""Image"",
      ""id"": ""http://image.example/3""
    }
  ]
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// On a Tombstone object, the             formerType property identifies the type of the object that was deleted.
        /// </summary>
        public Object? FormerType
        {
            get
            {
                return Property<Object>("formerType");
            }
            set
            {
                Property("formerType", value);
            }
        }

        /// <summary>
        /// On a Tombstone object, the             deleted property is a timestamp for when the object was deleted.
        /// </summary>
        public DateTime? Deleted
        {
            get
            {
                return Property<DateTime>("deleted");
            }
            set
            {
                Property("deleted", value);
            }
        }


    }
}