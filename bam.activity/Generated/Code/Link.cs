using System;

namespace Bam.Activity.Vocabulary
{
    public class Link : VocabularyObjectRoot
    {
        public Link(IdHost idHost) : base(idHost)
        {
            this.InitProperty("href", null, true, "xsd:anyURI");
            this.InitProperty("rel", null, false, "RFC5988", "[HTML5]");
            this.InitProperty("mediaType", null, true, "");
            this.InitProperty("name", null, false, "xsd:string", "rdf:langString");
            this.InitProperty("hreflang", null, true, "BCP47");
            this.InitProperty("height", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("width", null, true, "xsd:nonNegativeInteger");
            this.InitProperty("preview", null, false, "Link", "Object");
        }

        public Range<string>? Href
        {
            get
            {
                return Property("href") as Range<string>;
            }
            set
            {
                Property("href", value);
            }
        }
    
        public Range<string>? Rel
        {
            get
            {
                return Property("rel") as Range<string>;
            }
            set
            {
                Property("rel", value);
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
    
        public Range<string>? Hreflang
        {
            get
            {
                return Property("hreflang") as Range<string>;
            }
            set
            {
                Property("hreflang", value);
            }
        }
    
        public Range<ulong>? Height
        {
            get
            {
                return Property("height") as Range<ulong>;
            }
            set
            {
                Property("height", value);
            }
        }
    
        public Range<ulong>? Width
        {
            get
            {
                return Property("width") as Range<ulong>;
            }
            set
            {
                Property("width", value);
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
    

    }
}