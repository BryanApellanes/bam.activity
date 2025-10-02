using System;

namespace Bam.Activity.Vocabulary
{
    public interface IObject
    {

        public Range<Object, Link>? Attachment { get; set; }
        public Range<Link, Object>? AttributedTo { get; set; }
        public Range<Object, Link>? Audience { get; set; }
        public Range<string>? Content { get; set; }
        public Range<Object, Link>? Context { get; set; }
        public Range<string>? Name { get; set; }
        public Range<DateTime>? EndTime { get; set; }
        public Range<Object, Link>? Generator { get; set; }
        public Range<string, Link>? Icon { get; set; }
        public Range<string, Link>? Image { get; set; }
        public Range<Object, Link>? InReplyTo { get; set; }
        public Range<Object, Link>? Location { get; set; }
        public Range<Link, Object>? Preview { get; set; }
        public Range<DateTime>? Published { get; set; }
        public Range<Collection>? Replies { get; set; }
        public Range<DateTime>? StartTime { get; set; }
        public Range<string>? Summary { get; set; }
        public Range<Object, Link>? Tag { get; set; }
        public Range<DateTime>? Updated { get; set; }
        public Range<Link>? Url { get; set; }
        public Range<Object, Link>? To { get; set; }
        public Range<Object, Link>? Bto { get; set; }
        public Range<Object, Link>? Cc { get; set; }
        public Range<Object, Link>? Bcc { get; set; }
        public Object? MediaType { get; set; }
        public Range<TimeSpan>? Duration { get; set; }

    }
}