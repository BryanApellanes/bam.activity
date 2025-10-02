using System;

namespace Bam.Activity.Vocabulary
{
    public interface IRelationshipDescriptor
    {

        public Range<Link, Object>? Subject { get; set; }
        public Range<Object, Link>? Object { get; set; }
        public Range<Object>? Relationship { get; set; }

    }
}