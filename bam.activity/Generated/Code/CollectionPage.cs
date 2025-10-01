namespace Bam.Activity.Vocabulary
{
    public class CollectionPage : Collection
    {
        public CollectionPage(IdHost idHost) : base(idHost)
        {
            this.Property("partOf", null, true);
            this.Property("next", null, true);
            this.Property("prev", null, true);
            this.Property("Collection", null, true);
        }

        public object? PartOf => Property("partOf");
        public object? Next => Property("next");
        public object? Prev => Property("prev");
        public object? Collection => Property("Collection");

    }
}