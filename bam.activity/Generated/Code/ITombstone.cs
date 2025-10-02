using System;

namespace Bam.Activity.Vocabulary
{
    public interface ITombstone
    {

        public Range<Object>? FormerType { get; set; }
        public Range<DateTime>? Deleted { get; set; }

    }
}