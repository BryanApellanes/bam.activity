using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface IPlace
    {

        public float? Accuracy { get; set; }
        public float? Altitude { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public float? Radius { get; set; }
        public Range<decimal, string>? Units { get; set; }

    }
}