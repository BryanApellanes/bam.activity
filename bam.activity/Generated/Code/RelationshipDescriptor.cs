namespace Bam.Activity.Vocabulary
{
    public class RelationshipDescriptor : Object
    {
        public RelationshipDescriptor(IdHost idHost) : base(idHost)
        {
            this.Property("subject", null, true);
            this.Property("object", null, false);
            this.Property("relationship", null, false);
        }

        public object? Subject => Property("subject");
        public object? Object => Property("object");
        public object? Relationship => Property("relationship");

    }
}