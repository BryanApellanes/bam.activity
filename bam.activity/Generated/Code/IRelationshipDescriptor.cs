namespace Bam.Activity.Vocabulary
{
    public interface IRelationshipDescriptor
    {

        public object? Subject { get; set; }
        public object? Object { get; set; }
        public object? Relationship { get; set; }

    }
}