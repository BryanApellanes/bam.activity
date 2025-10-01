namespace Bam.Activity.Vocabulary
{
    public interface ICollectionPage
    {

        public object? PartOf { get; set; }
        public object? Next { get; set; }
        public object? Prev { get; set; }
        public object? Collection { get; set; }

    }
}