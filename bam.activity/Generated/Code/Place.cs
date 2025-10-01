namespace Bam.Activity.Vocabulary
{
    public class Place : Object
    {
        public Place(IdHost idHost) : base(idHost)
        {
            this.Property("accuracy", null, true);
            this.Property("altitude", null, true);
            this.Property("latitude", null, true);
            this.Property("longitude", null, true);
            this.Property("radius", null, true);
            this.Property("units", null, true);
            this.Property("Object", null, true);
        }

        public object? Accuracy => Property("accuracy");
        public object? Altitude => Property("altitude");
        public object? Latitude => Property("latitude");
        public object? Longitude => Property("longitude");
        public object? Radius => Property("radius");
        public object? Units => Property("units");
        public object? Object => Property("Object");

    }
}