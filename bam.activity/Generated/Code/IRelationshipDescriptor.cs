using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface IRelationshipDescriptor
    {

        public Range<Link, Object>? Subject { get; set; }
        public Range<Object, Link>? Object { get; set; }
        public Object? Relationship { get; set; }

    }
}