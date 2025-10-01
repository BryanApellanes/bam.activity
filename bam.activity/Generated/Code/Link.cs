namespace Bam.Activity.Vocabulary
{
    public class Link : VocabularyObjectRoot
    {
        public Link(IdHost idHost) : base(idHost)
        {
            this.Property("href", null, true);
            this.Property("rel", null, false);
            this.Property("mediaType", null, true);
            this.Property("name", null, false);
            this.Property("hreflang", null, true);
            this.Property("height", null, true);
            this.Property("width", null, true);
            this.Property("preview", null, false);
        }

        public object? Href
        {
            get
            {
                return Property("href");
            }
            set
            {
                Property("href", value);
            }
        }
    
        public object? Rel
        {
            get
            {
                return Property("rel");
            }
            set
            {
                Property("rel", value);
            }
        }
    
        public object? MediaType
        {
            get
            {
                return Property("mediaType");
            }
            set
            {
                Property("mediaType", value);
            }
        }
    
        public object? Name
        {
            get
            {
                return Property("name");
            }
            set
            {
                Property("name", value);
            }
        }
    
        public object? Hreflang
        {
            get
            {
                return Property("hreflang");
            }
            set
            {
                Property("hreflang", value);
            }
        }
    
        public object? Height
        {
            get
            {
                return Property("height");
            }
            set
            {
                Property("height", value);
            }
        }
    
        public object? Width
        {
            get
            {
                return Property("width");
            }
            set
            {
                Property("width", value);
            }
        }
    
        public object? Preview
        {
            get
            {
                return Property("preview");
            }
            set
            {
                Property("preview", value);
            }
        }
    

    }
}