using System;

namespace Bam.Activity.Vocabulary
{
    public interface IQuestion
    {

        public Range<Object, Link>? OneOf { get; set; }
        public Range<Object, Link>? AnyOf { get; set; }
        public Range<Object, Link>? Closed { get; set; }

    }
}