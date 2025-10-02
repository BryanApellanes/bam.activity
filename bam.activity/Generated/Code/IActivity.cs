using System;

namespace Bam.Activity.Vocabulary
{
    public interface IActivity
    {

        public Range<Object, Link>? Actor { get; set; }
        public Range<Object, Link>? Object { get; set; }
        public Range<Object, Link>? Target { get; set; }
        public Range<Object, Link>? Result { get; set; }
        public Range<Object, Link>? Origin { get; set; }
        public Range<Object, Link>? Instrument { get; set; }

    }
}