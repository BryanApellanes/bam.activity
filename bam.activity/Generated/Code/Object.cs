using System;

namespace Bam.Activity.Vocabulary
{
    public class Object : VocabularyObjectRoot
    {
        public Object(IdHost idHost) : base(idHost)
        {
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
            this.InitProperty("mediaType", null, true, "");
            this.InitProperty("duration", null, true, "xsd:duration");
        }

        public Range<Object, Link>? Attachment
        {
            get
            {
                return Property("attachment") as Range<Object, Link>;
            }
            set
            {
                Property("attachment", value);
            }
        }
    
        public Range<Link, Object>? AttributedTo
        {
            get
            {
                return Property("attributedTo") as Range<Link, Object>;
            }
            set
            {
                Property("attributedTo", value);
            }
        }
    
        public Range<Object, Link>? Audience
        {
            get
            {
                return Property("audience") as Range<Object, Link>;
            }
            set
            {
                Property("audience", value);
            }
        }
    
        public Range<string>? Content
        {
            get
            {
                return Property("content") as Range<string>;
            }
            set
            {
                Property("content", value);
            }
        }
    
        public Range<Object, Link>? Context
        {
            get
            {
                return Property("context") as Range<Object, Link>;
            }
            set
            {
                Property("context", value);
            }
        }
    
        public Range<string>? Name
        {
            get
            {
                return Property("name") as Range<string>;
            }
            set
            {
                Property("name", value);
            }
        }
    
        public Range<DateTime>? EndTime
        {
            get
            {
                return Property("endTime") as Range<DateTime>;
            }
            set
            {
                Property("endTime", value);
            }
        }
    
        public Range<Object, Link>? Generator
        {
            get
            {
                return Property("generator") as Range<Object, Link>;
            }
            set
            {
                Property("generator", value);
            }
        }
    
        public Range<string, Link>? Icon
        {
            get
            {
                return Property("icon") as Range<string, Link>;
            }
            set
            {
                Property("icon", value);
            }
        }
    
        public Range<string, Link>? Image
        {
            get
            {
                return Property("image") as Range<string, Link>;
            }
            set
            {
                Property("image", value);
            }
        }
    
        public Range<Object, Link>? InReplyTo
        {
            get
            {
                return Property("inReplyTo") as Range<Object, Link>;
            }
            set
            {
                Property("inReplyTo", value);
            }
        }
    
        public Range<Object, Link>? Location
        {
            get
            {
                return Property("location") as Range<Object, Link>;
            }
            set
            {
                Property("location", value);
            }
        }
    
        public Range<Link, Object>? Preview
        {
            get
            {
                return Property("preview") as Range<Link, Object>;
            }
            set
            {
                Property("preview", value);
            }
        }
    
        public Range<DateTime>? Published
        {
            get
            {
                return Property("published") as Range<DateTime>;
            }
            set
            {
                Property("published", value);
            }
        }
    
        public Range<Collection>? Replies
        {
            get
            {
                return Property("replies") as Range<Collection>;
            }
            set
            {
                Property("replies", value);
            }
        }
    
        public Range<DateTime>? StartTime
        {
            get
            {
                return Property("startTime") as Range<DateTime>;
            }
            set
            {
                Property("startTime", value);
            }
        }
    
        public Range<string>? Summary
        {
            get
            {
                return Property("summary") as Range<string>;
            }
            set
            {
                Property("summary", value);
            }
        }
    
        public Range<Object, Link>? Tag
        {
            get
            {
                return Property("tag") as Range<Object, Link>;
            }
            set
            {
                Property("tag", value);
            }
        }
    
        public Range<DateTime>? Updated
        {
            get
            {
                return Property("updated") as Range<DateTime>;
            }
            set
            {
                Property("updated", value);
            }
        }
    
        public Range<Link>? Url
        {
            get
            {
                return Property("url") as Range<Link>;
            }
            set
            {
                Property("url", value);
            }
        }
    
        public Range<Object, Link>? To
        {
            get
            {
                return Property("to") as Range<Object, Link>;
            }
            set
            {
                Property("to", value);
            }
        }
    
        public Range<Object, Link>? Bto
        {
            get
            {
                return Property("bto") as Range<Object, Link>;
            }
            set
            {
                Property("bto", value);
            }
        }
    
        public Range<Object, Link>? Cc
        {
            get
            {
                return Property("cc") as Range<Object, Link>;
            }
            set
            {
                Property("cc", value);
            }
        }
    
        public Range<Object, Link>? Bcc
        {
            get
            {
                return Property("bcc") as Range<Object, Link>;
            }
            set
            {
                Property("bcc", value);
            }
        }
    
        public Object? MediaType
        {
            get
            {
                return Property("mediaType") as Object;
            }
            set
            {
                Property("mediaType", value);
            }
        }
    
        public Range<TimeSpan>? Duration
        {
            get
            {
                return Property("duration") as Range<TimeSpan>;
            }
            set
            {
                Property("duration", value);
            }
        }
    

    }
}