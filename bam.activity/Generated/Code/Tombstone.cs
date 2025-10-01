namespace Bam.Activity.Vocabulary
{
    public class Tombstone : Object
    {
        public Tombstone(IdHost idHost) : base(idHost)
        {
            this.Property("formerType", null, false);
            this.Property("deleted", null, true);
            this.Property("Object", null, true);
        }

        public object? FormerType => Property("formerType");
        public object? Deleted => Property("deleted");
        public object? Object => Property("Object");

    }
}