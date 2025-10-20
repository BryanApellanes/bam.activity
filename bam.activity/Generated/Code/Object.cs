using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Describes an object of any kind. The Object type serves as the base type for most of the other kinds of objects defined in the Activity Vocabulary, including other Core types such as             Activity,             IntransitiveActivity,             Collection and             OrderedCollection.
    /// </summary>
    public partial class Object : VocabularyObjectRoot
    {
        public Object(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("attachment", null, false, "Object", "Link");
            this.InitProperty("attributedTo", null, false, "Link", "Object");
            this.InitProperty("audience", null, false, "Object", "Link");
            this.InitProperty("content", null, false, "xsd:string", "rdf:langString");
            this.InitProperty("context", null, false, "Object", "Link");
            this.InitProperty("name", null, false, "xsd:string", "rdf:langString");
            this.InitProperty("endTime", null, true, "xsd:dateTime");
            this.InitProperty("generator", null, false, "Object", "Link");
            this.InitProperty("icon", null, false, "Image", "Link");
            this.InitProperty("image", null, false, "Image", "Link");
            this.InitProperty("inReplyTo", null, false, "Object", "Link");
            this.InitProperty("location", null, false, "Object", "Link");
            this.InitProperty("preview", null, false, "Link", "Object");
            this.InitProperty("published", null, true, "xsd:dateTime");
            this.InitProperty("replies", null, true, "Collection");
            this.InitProperty("startTime", null, true, "xsd:dateTime");
            this.InitProperty("summary", null, false, "xsd:string", "rdf:langString");
            this.InitProperty("tag", null, false, "Object", "Link");
            this.InitProperty("updated", null, true, "xsd:dateTime");
            this.InitProperty("url", null, false, "Link");
            this.InitProperty("to", null, false, "Object", "Link");
            this.InitProperty("bto", null, false, "Object", "Link");
            this.InitProperty("cc", null, false, "Object", "Link");
            this.InitProperty("bcc", null, false, "Object", "Link");
            this.InitProperty("mediaType", null, true, string.Empty);
            this.InitProperty("duration", null, true, "xsd:duration");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Object"",
  ""id"": ""http://www.test.example/object/1"",
  ""name"": ""A Simple, non-specific object""
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// Identifies a resource attached or related to an object that potentially requires special handling. The intent is to provide a model that is at least semantically similar to attachments in email.
        /// </summary>
        public Range<Object, Link>? Attachment
        {
            get
            {
                return Property<Range<Object, Link>>("attachment");
            }
            set
            {
                Property("attachment", value);
            }
        }

        /// <summary>
        /// Identifies one or more entities to which this object is attributed. The attributed entities might not be Actors. For instance, an object might be attributed to the completion of another activity.
        /// </summary>
        public Range<Link, Object>? AttributedTo
        {
            get
            {
                return Property<Range<Link, Object>>("attributedTo");
            }
            set
            {
                Property("attributedTo", value);
            }
        }

        /// <summary>
        /// Identifies one or more entities that represent the total population of entities for which the object can considered to be relevant.
        /// </summary>
        public Range<Object, Link>? Audience
        {
            get
            {
                return Property<Range<Object, Link>>("audience");
            }
            set
            {
                Property("audience", value);
            }
        }

        /// <summary>
        /// The content or textual representation of the Object encoded as a JSON string. By default, the value of content is HTML. The mediaType property can be used in the object to indicate a different content type.                                         The content MAY be expressed using multiple language-tagged values.
        /// </summary>
        public string? Content
        {
            get
            {
                return Property<string>("content");
            }
            set
            {
                Property("content", value);
            }
        }

        /// <summary>
        /// Identifies the context within which the object exists or an activity was performed.                                         The notion of 'context' used is intentionally vague. The intended function is to serve as a means of grouping objects and activities that share a common originating context or purpose. An example could be all activities relating to a common project or event.
        /// </summary>
        public Range<Object, Link>? Context
        {
            get
            {
                return Property<Range<Object, Link>>("context");
            }
            set
            {
                Property("context", value);
            }
        }

        /// <summary>
        /// A simple, human-readable, plain-text name for the object. HTML markup MUST NOT be included. The name MAY be expressed using multiple language-tagged values.
        /// </summary>
        public string? Name
        {
            get
            {
                return Property<string>("name");
            }
            set
            {
                Property("name", value);
            }
        }

        /// <summary>
        /// The date and time describing the actual or expected ending time of the object. When used with an Activity object, for instance, the endTime property specifies the moment the activity concluded or is expected to conclude.
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                return Property<DateTime>("endTime");
            }
            set
            {
                Property("endTime", value);
            }
        }

        /// <summary>
        /// Identifies the entity (e.g. an application) that generated the object.
        /// </summary>
        public Range<Object, Link>? Generator
        {
            get
            {
                return Property<Range<Object, Link>>("generator");
            }
            set
            {
                Property("generator", value);
            }
        }

        /// <summary>
        /// Indicates an entity that describes an icon for this object. The image should have an aspect ratio of one (horizontal) to one (vertical) and should be suitable for presentation at a small size.
        /// </summary>
        public Range<string, Link>? Icon
        {
            get
            {
                return Property<Range<string, Link>>("icon");
            }
            set
            {
                Property("icon", value);
            }
        }

        /// <summary>
        /// Indicates an entity that describes an image for this object. Unlike the icon property, there are no aspect ratio or display size limitations assumed.
        /// </summary>
        public Range<string, Link>? Image
        {
            get
            {
                return Property<Range<string, Link>>("image");
            }
            set
            {
                Property("image", value);
            }
        }

        /// <summary>
        /// Indicates one or more entities for which this object is considered a response.
        /// </summary>
        public Range<Object, Link>? InReplyTo
        {
            get
            {
                return Property<Range<Object, Link>>("inReplyTo");
            }
            set
            {
                Property("inReplyTo", value);
            }
        }

        /// <summary>
        /// Indicates one or more physical or logical locations associated with the object.
        /// </summary>
        public Range<Object, Link>? Location
        {
            get
            {
                return Property<Range<Object, Link>>("location");
            }
            set
            {
                Property("location", value);
            }
        }

        /// <summary>
        /// Identifies an entity that provides a preview of this object.
        /// </summary>
        public Range<Link, Object>? Preview
        {
            get
            {
                return Property<Range<Link, Object>>("preview");
            }
            set
            {
                Property("preview", value);
            }
        }

        /// <summary>
        /// The date and time at which the object was published
        /// </summary>
        public DateTime? Published
        {
            get
            {
                return Property<DateTime>("published");
            }
            set
            {
                Property("published", value);
            }
        }

        /// <summary>
        /// Identifies a Collection containing objects considered to be responses to this object.
        /// </summary>
        public Collection? Replies
        {
            get
            {
                return Property<Collection>("replies");
            }
            set
            {
                Property("replies", value);
            }
        }

        /// <summary>
        /// The date and time describing the actual or expected starting time of the object. When used with an Activity object, for instance, the startTime property specifies the moment the activity began or is scheduled to begin.
        /// </summary>
        public DateTime? StartTime
        {
            get
            {
                return Property<DateTime>("startTime");
            }
            set
            {
                Property("startTime", value);
            }
        }

        /// <summary>
        /// A natural language summarization of the object encoded as HTML. Multiple language tagged summaries MAY be provided.
        /// </summary>
        public string? Summary
        {
            get
            {
                return Property<string>("summary");
            }
            set
            {
                Property("summary", value);
            }
        }

        /// <summary>
        /// One or more 'tags' that have been associated with an objects. A tag can be any kind of Object. The key difference between             attachment and tag is that the former implies association by inclusion, while the latter implies associated by reference.
        /// </summary>
        public Range<Object, Link>? Tag
        {
            get
            {
                return Property<Range<Object, Link>>("tag");
            }
            set
            {
                Property("tag", value);
            }
        }

        /// <summary>
        /// The date and time at which the object was updated
        /// </summary>
        public DateTime? Updated
        {
            get
            {
                return Property<DateTime>("updated");
            }
            set
            {
                Property("updated", value);
            }
        }

        /// <summary>
        /// Identifies one or more links to representations of the object
        /// </summary>
        public Link? Url
        {
            get
            {
                return Property<Link>("url");
            }
            set
            {
                Property("url", value);
            }
        }

        /// <summary>
        /// Identifies an entity considered to be part of the public primary audience of an Object
        /// </summary>
        public Range<Object, Link>? To
        {
            get
            {
                return Property<Range<Object, Link>>("to");
            }
            set
            {
                Property("to", value);
            }
        }

        /// <summary>
        /// Identifies an Object that is part of the private primary audience of this Object.
        /// </summary>
        public Range<Object, Link>? Bto
        {
            get
            {
                return Property<Range<Object, Link>>("bto");
            }
            set
            {
                Property("bto", value);
            }
        }

        /// <summary>
        /// Identifies an Object that is part of the public secondary audience of this Object.
        /// </summary>
        public Range<Object, Link>? Cc
        {
            get
            {
                return Property<Range<Object, Link>>("cc");
            }
            set
            {
                Property("cc", value);
            }
        }

        /// <summary>
        /// Identifies one or more Objects that are part of the private secondary audience of this Object.
        /// </summary>
        public Range<Object, Link>? Bcc
        {
            get
            {
                return Property<Range<Object, Link>>("bcc");
            }
            set
            {
                Property("bcc", value);
            }
        }

        /// <summary>
        /// When used on a Link, identifies the MIME media type of the referenced resource.                                         When used on an Object, identifies the MIME media type of the value of the content property. If not specified, the content property is assumed to contain text/html content.
        /// </summary>
        public Object? MediaType
        {
            get
            {
                return Property<Object>("mediaType");
            }
            set
            {
                Property("mediaType", value);
            }
        }

        /// <summary>
        /// When the object describes a time-bound resource, such as an audio or video, a meeting, etc, the duration property indicates the object's approximate duration. The value MUST be expressed as an xsd:duration as defined by [             xmlschema11-2], section 3.3.6 (e.g. a period of 5 seconds is represented as 'PT5S').
        /// </summary>
        public Duration? Duration
        {
            get
            {
                return Property<Duration>("duration");
            }
            set
            {
                Property("duration", value);
            }
        }


    }
}