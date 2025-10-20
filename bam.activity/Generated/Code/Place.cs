using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a logical or physical location. See               5.3 Representing Places for additional information.
    /// </summary>
    public partial class Place : Object, IPlace
    {
        public Place(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("accuracy", null, true, "xsd:float");
            this.InitProperty("altitude", null, true, "xsd:float");
            this.InitProperty("latitude", null, true, "xsd:float");
            this.InitProperty("longitude", null, true, "xsd:float");
            this.InitProperty("radius", null, true, "xsd:float");
            this.InitProperty("units", null, true, "cm", "feet", "inches", "km", "m", "miles", "xsd:anyURI");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Place"",
  ""name"": ""Work""
}");
            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Place"",
  ""name"": ""Fresno Area"",
  ""latitude"": 36.75,
  ""longitude"": 119.7667,
  ""radius"": 15,
  ""units"": ""miles""
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// Indicates the accuracy of position coordinates on a             Place objects. Expressed in properties of percentage. e.g. '94.0' means '94.0% accurate'.
        /// </summary>
        public float? Accuracy
        {
            get
            {
                return Property<float>("accuracy");
            }
            set
            {
                Property("accuracy", value);
            }
        }

        /// <summary>
        /// Indicates the altitude of a place. The measurement units is indicated using the units property. If             units is not specified, the default is assumed to be 'm' indicating meters.
        /// </summary>
        public float? Altitude
        {
            get
            {
                return Property<float>("altitude");
            }
            set
            {
                Property("altitude", value);
            }
        }

        /// <summary>
        /// The latitude of a place
        /// </summary>
        public float? Latitude
        {
            get
            {
                return Property<float>("latitude");
            }
            set
            {
                Property("latitude", value);
            }
        }

        /// <summary>
        /// The longitude of a place
        /// </summary>
        public float? Longitude
        {
            get
            {
                return Property<float>("longitude");
            }
            set
            {
                Property("longitude", value);
            }
        }

        /// <summary>
        /// The radius from the given latitude and longitude for a Place. The units is expressed by the units property. If units is not specified, the default is assumed to be 'm' indicating 'meters'.
        /// </summary>
        public float? Radius
        {
            get
            {
                return Property<float>("radius");
            }
            set
            {
                Property("radius", value);
            }
        }

        /// <summary>
        /// Specifies the measurement units for the radius and altitude properties on a             Place object. If not specified, the default is assumed to be 'm' for 'meters'.
        /// </summary>
        public Range<decimal, string>? Units
        {
            get
            {
                return Property<Range<decimal, string>>("units");
            }
            set
            {
                Property("units", value);
            }
        }


    }
}