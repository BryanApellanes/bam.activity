namespace Bam.Activity.Vocabulary
{
    public class OrderedCollectionPage : OrderedCollection
    {
        public OrderedCollectionPage(IdHost idHost) : base(idHost)
        {
            this.Property("startIndex", null, true);
            this.Property("OrderedCollection", null, true);
            this.Property("CollectionPage", null, true);
        }

        public object? StartIndex => Property("startIndex");
        public object? OrderedCollection => Property("OrderedCollection");
        public object? CollectionPage => Property("CollectionPage");

    }
}