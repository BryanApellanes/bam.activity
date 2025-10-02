using System;

namespace Bam.Activity.Vocabulary
{
    public interface IPlace
    {

        public Range<float>? Accuracy { get; set; }
        public Range<float>? Altitude { get; set; }
        public Range<float>? Latitude { get; set; }
        public Range<float>? Longitude { get; set; }
        public Range<float>? Radius { get; set; }
        public Range<decimal, string>? Units { get; set; }

    }
}