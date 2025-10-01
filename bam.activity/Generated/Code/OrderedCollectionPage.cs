namespace Bam.Activity.Vocabulary
{
    public class OrderedCollectionPage : VocabularyObjectRoot, IOrderedCollection, ICollectionPage, IOrderedCollectionPage
    {
        public OrderedCollectionPage(IdHost idHost) : base(idHost)
        {
            this.Property("startIndex", null, true);
            this.Property("OrderedCollection", null, true);
            this.Property("CollectionPage", null, true);
            this.Property("partOf", null, true);
            this.Property("next", null, true);
            this.Property("prev", null, true);
            this.Property("Collection", null, true);
        }

        public object? StartIndex
        {
            get
            {
                return Property("startIndex");
            }
            set
            {
                Property("startIndex", value);
            }
        }
    
        public object? OrderedCollection
        {
            get
            {
                return Property("OrderedCollection");
            }
            set
            {
                Property("OrderedCollection", value);
            }
        }
    
        public object? CollectionPage
        {
            get
            {
                return Property("CollectionPage");
            }
            set
            {
                Property("CollectionPage", value);
            }
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