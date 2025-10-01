namespace Bam.Activity.Vocabulary
{
    public interface ILink
    {

        public object? Href { get; set; }
        public object? Rel { get; set; }
        public object? MediaType { get; set; }
        public object? Name { get; set; }
        public object? Hreflang { get; set; }
        public object? Height { get; set; }
        public object? Width { get; set; }
        public object? Preview { get; set; }

    }
}