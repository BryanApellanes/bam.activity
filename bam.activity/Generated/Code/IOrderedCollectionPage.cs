namespace Bam.Activity.Vocabulary
{
    public interface IOrderedCollectionPage
    {

        public object? StartIndex { get; set; }
        public object? OrderedCollection { get; set; }
        public object? CollectionPage { get; set; }
        public object? PartOf { get; set; }
        public object? Next { get; set; }
        public object? Prev { get; set; }
        public object? Collection { get; set; }

    }
}