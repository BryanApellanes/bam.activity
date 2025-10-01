namespace Bam.Activity.Vocabulary
{
    public class Object : ObjectBase
    {
        public Object(IdHost idHost) : base(idHost)
        {
            this.Property("attachment", null, false);
            this.Property("attributedTo", null, false);
            this.Property("audience", null, false);
            this.Property("content", null, false);
            this.Property("context", null, false);
            this.Property("name", null, false);
            this.Property("endTime", null, true);
            this.Property("generator", null, false);
            this.Property("icon", null, false);
            this.Property("image", null, false);
            this.Property("inReplyTo", null, false);
            this.Property("location", null, false);
            this.Property("preview", null, false);
            this.Property("published", null, true);
            this.Property("replies", null, true);
            this.Property("startTime", null, true);
            this.Property("summary", null, false);
            this.Property("tag", null, false);
            this.Property("updated", null, true);
            this.Property("url", null, false);
            this.Property("to", null, false);
            this.Property("bto", null, false);
            this.Property("cc", null, false);
            this.Property("bcc", null, false);
            this.Property("mediaType", null, true);
            this.Property("duration", null, true);
        }

        public object? Attachment => Property("attachment");
        public object? AttributedTo => Property("attributedTo");
        public object? Audience => Property("audience");
        public object? Content => Property("content");
        public object? Context => Property("context");
        public object? Name => Property("name");
        public object? EndTime => Property("endTime");
        public object? Generator => Property("generator");
        public object? Icon => Property("icon");
        public object? Image => Property("image");
        public object? InReplyTo => Property("inReplyTo");
        public object? Location => Property("location");
        public object? Preview => Property("preview");
        public object? Published => Property("published");
        public object? Replies => Property("replies");
        public object? StartTime => Property("startTime");
        public object? Summary => Property("summary");
        public object? Tag => Property("tag");
        public object? Updated => Property("updated");
        public object? Url => Property("url");
        public object? To => Property("to");
        public object? Bto => Property("bto");
        public object? Cc => Property("cc");
        public object? Bcc => Property("bcc");
        public object? MediaType => Property("mediaType");
        public object? Duration => Property("duration");

    }
}