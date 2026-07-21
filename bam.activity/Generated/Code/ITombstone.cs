using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface ITombstone
    {

        public Object? FormerType { get; set; }
        public DateTime? Deleted { get; set; }

    }
}