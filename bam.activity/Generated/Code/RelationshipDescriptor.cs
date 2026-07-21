using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Describes a relationship between two individuals. The subject and                 object properties are used to identify the connected individuals.                                               See 5.2 Representing Relationships Between Entities for additional information.
    /// </summary>
    public partial class RelationshipDescriptor : Object, IRelationshipDescriptor
    {
        public RelationshipDescriptor(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("subject", null, true, "Link", "Object");
            this.InitProperty("object", null, false, "Object", "Link");
            this.InitProperty("relationship", null, false, "Object");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""summary"": ""Sally is an acquaintance of John"",
  ""type"": ""Relationship"",
  ""subject"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""relationship"": ""http://purl.org/vocab/relationship/acquaintanceOf"",
  ""object"": {
    ""type"": ""Person"",
    ""name"": ""John""
  }
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// On a Relationship object, the subject property identifies one of the connected individuals. For instance, for a Relationship object describing 'John is related to Sally', subject would refer to John.
        /// </summary>
        public Range<Link, Object>? Subject
        {
            get
            {
                return Property<Range<Link, Object>>("subject");
            }
            set
            {
                Property("subject", value);
            }
        }

        /// <summary>
        /// When used within an Activity, describes the direct object of the activity. For instance, in the activity 'John added a movie to his wishlist', the object of the activity is the movie added.                                         When used within a Relationship describes the entity to which the subject is related.
        /// </summary>
        public Range<Object, Link>? Object
        {
            get
            {
                return Property<Range<Object, Link>>("object");
            }
            set
            {
                Property("object", value);
            }
        }

        /// <summary>
        /// On a Relationship object, the             relationship property identifies the kind of relationship that exists between             subject and             object.
        /// </summary>
        public Object? Relationship
        {
            get
            {
                return Property<Object>("relationship");
            }
            set
            {
                Property("relationship", value);
            }
        }


    }
}