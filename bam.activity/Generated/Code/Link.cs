namespace Bam.Activity.Vocabulary
{
    public class Link : ObjectBase
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

        public object? Href => Property("href");
        public object? Rel => Property("rel");
        public object? MediaType => Property("mediaType");
        public object? Name => Property("name");
        public object? Hreflang => Property("hreflang");
        public object? Height => Property("height");
        public object? Width => Property("width");
        public object? Preview => Property("preview");

    }
}