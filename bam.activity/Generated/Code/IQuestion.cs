namespace Bam.Activity.Vocabulary
{
    public interface IQuestion
    {

        public object? OneOf { get; set; }
        public object? AnyOf { get; set; }
        public object? Closed { get; set; }
        public object? IntransitiveActivity { get; set; }

    }
}