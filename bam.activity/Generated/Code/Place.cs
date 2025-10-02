using System;

namespace Bam.Activity.Vocabulary
{
    public class Place : Object, IPlace
    {
        public Place(IdHost idHost) : base(idHost)
        {
            this.InitProperty("accuracy", null, true, "xsd:float");
            this.InitProperty("altitude", null, true, "xsd:float");
            this.InitProperty("latitude", null, true, "xsd:float");
            this.InitProperty("longitude", null, true, "xsd:float");
            this.InitProperty("radius", null, true, "xsd:float");
            this.InitProperty("units", null, true, "cm", "feet", "inches", "km", "m", "miles", "xsd:anyURI");
        }

        public Range<float>? Accuracy
        {
            get
            {
                return Property("accuracy") as Range<float>;
            }
            set
            {
                Property("accuracy", value);
            }
        }
    
        public Range<float>? Altitude
        {
            get
            {
                return Property("altitude") as Range<float>;
            }
            set
            {
                Property("altitude", value);
            }
        }
    
        public Range<float>? Latitude
        {
            get
            {
                return Property("latitude") as Range<float>;
            }
            set
            {
                Property("latitude", value);
            }
        }
    
        public Range<float>? Longitude
        {
            get
            {
                return Property("longitude") as Range<float>;
            }
            set
            {
                Property("longitude", value);
            }
        }
    
        public Range<float>? Radius
        {
            get
            {
                return Property("radius") as Range<float>;
            }
            set
            {
                Property("radius", value);
            }
        }
    
        public Range<decimal, string>? Units
        {
            get
            {
                return Property("units") as Range<decimal, string>;
            }
            set
            {
                Property("units", value);
            }
        }
    

    }
}