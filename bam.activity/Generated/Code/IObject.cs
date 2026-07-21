using System;

namespace Bam.Activity.Vocabulary
{
    public partial interface IObject
    {

        public Range<Object, Link>? Attachment { get; set; }
        public Range<Link, Object>? AttributedTo { get; set; }
        public Range<Object, Link>? Audience { get; set; }
        public string? Content { get; set; }
        public Range<Object, Link>? Context { get; set; }
        public string? Name { get; set; }
        public DateTime? EndTime { get; set; }
        public Range<Object, Link>? Generator { get; set; }
        public Range<string, Link>? Icon { get; set; }
        public Range<string, Link>? Image { get; set; }
        public Range<Object, Link>? InReplyTo { get; set; }
        public Range<Object, Link>? Location { get; set; }
        public Range<Link, Object>? Preview { get; set; }
        public DateTime? Published { get; set; }
        public Collection? Replies { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Summary { get; set; }
        public Range<Object, Link>? Tag { get; set; }
        public DateTime? Updated { get; set; }
        public Link? Url { get; set; }
        public Range<Object, Link>? To { get; set; }
        public Range<Object, Link>? Bto { get; set; }
        public Range<Object, Link>? Cc { get; set; }
        public Range<Object, Link>? Bcc { get; set; }
        public Object? MediaType { get; set; }
        public Duration? Duration { get; set; }

    }
}