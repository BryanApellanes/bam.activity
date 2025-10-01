namespace Bam.Activity.Vocabulary
{
    public class Question : IntransitiveActivity
    {
        public Question(IdHost idHost) : base(idHost)
        {
            this.Property("oneOf", null, false);
            this.Property("anyOf", null, false);
            this.Property("closed", null, false);
            this.Property("IntransitiveActivity", null, true);
        }

        public object? OneOf => Property("oneOf");
        public object? AnyOf => Property("anyOf");
        public object? Closed => Property("closed");
        public object? IntransitiveActivity => Property("IntransitiveActivity");

    }
}