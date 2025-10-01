namespace Bam.Activity.Vocabulary
{
    public interface ICollection
    {

        public object? TotalItems { get; set; }
        public object? Current { get; set; }
        public object? First { get; set; }
        public object? Last { get; set; }
        public object? Items { get; set; }
        public object? Object { get; set; }

    }
}