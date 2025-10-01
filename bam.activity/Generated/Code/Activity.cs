namespace Bam.Activity.Vocabulary
{
    public class Activity : Object
    {
        public Activity(IdHost idHost) : base(idHost)
        {
            this.Property("actor", null, false);
            this.Property("object", null, false);
            this.Property("target", null, false);
            this.Property("result", null, false);
            this.Property("origin", null, false);
            this.Property("instrument", null, false);
        }

        public object? Actor => Property("actor");
        public object? Object => Property("object");
        public object? Target => Property("target");
        public object? Result => Property("result");
        public object? Origin => Property("origin");
        public object? Instrument => Property("instrument");

    }
}