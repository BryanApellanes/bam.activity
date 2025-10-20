using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// An Activity is a subtype of Object that describes some form of action that may happen, is currently happening, or has already happened. The Activity type itself serves as an abstract base type for all types of activities. It is important to note that the Activity type itself does not carry any specific semantics about the kind of action being taken.
    /// </summary>
    public partial class Activity : Object, IActivity
    {
        public Activity(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("actor", null, false, "Object", "Link");
            this.InitProperty("object", null, false, "Object", "Link");
            this.InitProperty("target", null, false, "Object", "Link");
            this.InitProperty("result", null, false, "Object", "Link");
            this.InitProperty("origin", null, false, "Object", "Link");
            this.InitProperty("instrument", null, false, "Object", "Link");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Activity"",
  ""summary"": ""Sally did something to a note"",
  ""actor"": {
    ""type"": ""Person"",
    ""name"": ""Sally""
  },
  ""object"": {
    ""type"": ""Note"",
    ""name"": ""A Note""
  }
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// Describes one or more entities that either performed or are expected to perform the activity. Any single activity can have multiple actors. The actor MAY be specified using an indirect Link.
        /// </summary>
        public Range<Object, Link>? Actor
        {
            get
            {
                return Property<Range<Object, Link>>("actor");
            }
            set
            {
                Property("actor", value);
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
        /// Describes the indirect object, or target, of the activity. The precise meaning of the target is largely dependent on the type of action being described but will often be the object of the English preposition 'to'. For instance, in the activity 'John added a movie to his wishlist', the target of the activity is John's wishlist. An activity can have more than one target.
        /// </summary>
        public Range<Object, Link>? Target
        {
            get
            {
                return Property<Range<Object, Link>>("target");
            }
            set
            {
                Property("target", value);
            }
        }

        /// <summary>
        /// Describes the result of the activity. For instance, if a particular action results in the creation of a new resource, the result property can be used to describe that new resource.
        /// </summary>
        public Range<Object, Link>? Result
        {
            get
            {
                return Property<Range<Object, Link>>("result");
            }
            set
            {
                Property("result", value);
            }
        }

        /// <summary>
        /// Describes an indirect object of the activity from which the activity is directed. The precise meaning of the origin is the object of the English preposition 'from'. For instance, in the activity 'John moved an item to List B from List A', the origin of the activity is 'List A'.
        /// </summary>
        public Range<Object, Link>? Origin
        {
            get
            {
                return Property<Range<Object, Link>>("origin");
            }
            set
            {
                Property("origin", value);
            }
        }

        /// <summary>
        /// Identifies one or more objects used (or to be used) in the completion of an Activity.
        /// </summary>
        public Range<Object, Link>? Instrument
        {
            get
            {
                return Property<Range<Object, Link>>("instrument");
            }
            set
            {
                Property("instrument", value);
            }
        }


    }
}