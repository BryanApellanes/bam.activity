namespace Bam.Activity.Vocabulary
{
    public class RelationshipDescriptor : Object, IRelationshipDescriptor
    {
        public RelationshipDescriptor(IdHost idHost) : base(idHost)
        {
            this.Property("subject", null, true);
            this.Property("object", null, false);
            this.Property("relationship", null, false);
        }

        public object? Subject
        {
            get
            {
                return Property("subject");
            }
            set
            {
                Property("subject", value);
            }
        }
    
        public object? Object
        {
            get
            {
                return Property("object");
            }
            set
            {
                Property("object", value);
            }
        }
    
        public object? Relationship
        {
            get
            {
                return Property("relationship");
            }
            set
            {
                Property("relationship", value);
            }
        }
    

    }
}