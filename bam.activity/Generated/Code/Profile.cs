namespace Bam.Activity.Vocabulary
{
    public class Profile : Object
    {
        public Profile(IdHost idHost) : base(idHost)
        {
            this.Property("describes", null, true);
            this.Property("Object", null, true);
        }

        public object? Describes => Property("describes");
        public object? Object => Property("Object");

    }
}