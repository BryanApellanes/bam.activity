namespace Bam.Activity.Vocabulary
{
    public interface IActivity
    {

        public object? Actor { get; set; }
        public object? Object { get; set; }
        public object? Target { get; set; }
        public object? Result { get; set; }
        public object? Origin { get; set; }
        public object? Instrument { get; set; }

    }
}