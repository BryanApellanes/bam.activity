namespace Bam.Activity.Vocabulary
{
    public class Collection : Object, ICollection
    {
        public Collection(IdHost idHost) : base(idHost)
        {
            this.Property("totalItems", null, true);
            this.Property("current", null, true);
            this.Property("first", null, true);
            this.Property("last", null, true);
            this.Property("items", null, false);
            this.Property("Object", null, true);
        }

        public object? TotalItems
        {
            get
            {
                return Property("totalItems");
            }
            set
            {
                Property("totalItems", value);
            }
        }
    
        public object? Current
        {
            get
            {
                return Property("current");
            }
            set
            {
                Property("current", value);
            }
        }
    
        public object? First
        {
            get
            {
                return Property("first");
            }
            set
            {
                Property("first", value);
            }
        }
    
        public object? Last
        {
            get
            {
                return Property("last");
            }
            set
            {
                Property("last", value);
            }
        }
    
        public object? Items
        {
            get
            {
                return Property("items");
            }
            set
            {
                Property("items", value);
            }
        }
    
        public object? Object
        {
            get
            {
                return Property("Object");
            }
            set
            {
                Property("Object", value);
            }
        }
    

    }
}