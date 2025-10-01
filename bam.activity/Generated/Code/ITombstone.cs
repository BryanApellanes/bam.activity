namespace Bam.Activity.Vocabulary
{
    public interface ITombstone
    {

        public object? FormerType { get; set; }
        public object? Deleted { get; set; }
        public object? Object { get; set; }

    }
}