namespace Bam.Activity.Vocabulary
{
    public class Place : Object, IPlace
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

        public object? Accuracy
        {
            get
            {
                return Property("accuracy");
            }
            set
            {
                Property("accuracy", value);
            }
        }
    
        public object? Altitude
        {
            get
            {
                return Property("altitude");
            }
            set
            {
                Property("altitude", value);
            }
        }
    
        public object? Latitude
        {
            get
            {
                return Property("latitude");
            }
            set
            {
                Property("latitude", value);
            }
        }
    
        public object? Longitude
        {
            get
            {
                return Property("longitude");
            }
            set
            {
                Property("longitude", value);
            }
        }
    
        public object? Radius
        {
            get
            {
                return Property("radius");
            }
            set
            {
                Property("radius", value);
            }
        }
    
        public object? Units
        {
            get
            {
                return Property("units");
            }
            set
            {
                Property("units", value);
            }
        }
    
        public object? Object
        {
            get
            {
                return Property("Object");
            }
            set
            {
                Property("Object", value);
            }
        }
    

    }
}