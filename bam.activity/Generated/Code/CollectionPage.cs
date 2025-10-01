namespace Bam.Activity.Vocabulary
{
    public class CollectionPage : Collection, ICollectionPage
    {
        public CollectionPage(IdHost idHost) : base(idHost)
        {
            this.Property("partOf", null, true);
            this.Property("next", null, true);
            this.Property("prev", null, true);
            this.Property("Collection", null, true);
        }

        public object? PartOf
        {
            get
            {
                return Property("partOf");
            }
            set
            {
                Property("partOf", value);
            }
        }
    
        public object? Next
        {
            get
            {
                return Property("next");
            }
            set
            {
                Property("next", value);
            }
        }
    
        public object? Prev
        {
            get
            {
                return Property("prev");
            }
            set
            {
                Property("prev", value);
            }
        }
    
        public object? Collection
        {
            get
            {
                return Property("Collection");
            }
            set
            {
                Property("Collection", value);
            }
        }
    

    }
}