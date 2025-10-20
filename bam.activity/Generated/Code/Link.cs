using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A Link is an indirect, qualified reference to a resource identified by a URL. The fundamental model for links is established by [             RFC5988]. Many of the properties defined by the Activity Vocabulary allow values that are either instances of             Object or Link. When a Link is used, it establishes a             qualified relation connecting the subject (the containing object) to the resource identified by the href. Properties of the Link are properties of the reference as opposed to properties of the resource.
    /// </summary>
    public partial class Link : Object, ILink
    {
        public Link(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("href", null, true, "xsd:anyURI");
            this.InitProperty("rel", null, false, "RFC5988", "[HTML5]");
            this.InitProperty("mediaType", null, true, string.Empty);
            this.InitProperty("name", null, false, "xsd:string", "rdf:langString");
            this.InitProperty("hreflang", null, true, "BCP47");
            this.InitProperty("height", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("width", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("preview", null, false, "Link", "Object");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Link"",
  ""href"": ""http://example.org/abc"",
  ""hreflang"": ""en"",
  ""mediaType"": ""text/html"",
  ""name"": ""An example link""
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// The target resource pointed to by a Link.
        /// </summary>
        public string? Href
        {
            get
            {
                return Property<string>("href");
            }
            set
            {
                Property("href", value);
            }
        }

        /// <summary>
        /// A link relation associated with a Link. The value MUST conform to both the [HTML5] and [RFC5988] 'link relation' definitions.             In the [HTML5], any string not containing the 'space' U+0020, 'tab' (U+0009), 'LF' (U+000A), 'FF' (U+000C), 'CR' (U+000D) or ',' (U+002C) characters can be used as a valid link relation.
        /// </summary>
        public string? Rel
        {
            get
            {
                return Property<string>("rel");
            }
            set
            {
                Property("rel", value);
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
        /// Hints as to the language used by the target resource. Value MUST be a [BCP47] Language-Tag.
        /// </summary>
        public string? Hreflang
        {
            get
            {
                return Property<string>("hreflang");
            }
            set
            {
                Property("hreflang", value);
            }
        }

        /// <summary>
        /// On a Link, specifies a hint as to the rendering height in device-independent pixels of the linked resource.
        /// </summary>
        public ulong? Height
        {
            get
            {
                return Property<ulong>("height");
            }
            set
            {
                Property("height", value);
            }
        }

        /// <summary>
        /// On a Link, specifies a hint as to the rendering width in device-independent pixels of the linked resource.
        /// </summary>
        public ulong? Width
        {
            get
            {
                return Property<ulong>("width");
            }
            set
            {
                Property("width", value);
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


    }
}