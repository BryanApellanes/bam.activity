using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface IQuestion
    {

        public Range<Object, Link>? OneOf { get; set; }
        public Range<Object, Link>? AnyOf { get; set; }
        public Range<Object, Link>? Closed { get; set; }

    }
}