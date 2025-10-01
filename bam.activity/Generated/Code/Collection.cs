namespace Bam.Activity.Vocabulary
{
    public class Collection : Object
    {
        public Collection(IdHost idHost) : base(idHost)
        {
            this.Property("totalItems", null, true);
            this.Property("current", null, true);
            this.Property("first", null, true);
            this.Property("last", null, true);
            this.Property("items", null, false);
            this.Property("Object", null, true);
        }

        public object? TotalItems => Property("totalItems");
        public object? Current => Property("current");
        public object? First => Property("first");
        public object? Last => Property("last");
        public object? Items => Property("items");
        public object? Object => Property("Object");

    }
}