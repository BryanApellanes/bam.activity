namespace Bam.Activity.Vocabulary
{
    public class Tombstone : Object, ITombstone
    {
        public Tombstone(IdHost idHost) : base(idHost)
        {
            this.Property("formerType", null, false);
            this.Property("deleted", null, true);
            this.Property("Object", null, true);
        }

        public object? FormerType
        {
            get
            {
                return Property("formerType");
            }
            set
            {
                Property("formerType", value);
            }
        }
    
        public object? Deleted
        {
            get
            {
                return Property("deleted");
            }
            set
            {
                Property("deleted", value);
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