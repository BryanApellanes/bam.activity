namespace Bam.Activity.Vocabulary
{
    public class Object : VocabularyObjectRoot
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

        public object? Attachment
        {
            get
            {
                return Property("attachment");
            }
            set
            {
                Property("attachment", value);
            }
        }
    
        public object? AttributedTo
        {
            get
            {
                return Property("attributedTo");
            }
            set
            {
                Property("attributedTo", value);
            }
        }
    
        public object? Audience
        {
            get
            {
                return Property("audience");
            }
            set
            {
                Property("audience", value);
            }
        }
    
        public object? Content
        {
            get
            {
                return Property("content");
            }
            set
            {
                Property("content", value);
            }
        }
    
        public object? Context
        {
            get
            {
                return Property("context");
            }
            set
            {
                Property("context", value);
            }
        }
    
        public object? Name
        {
            get
            {
                return Property("name");
            }
            set
            {
                Property("name", value);
            }
        }
    
        public object? EndTime
        {
            get
            {
                return Property("endTime");
            }
            set
            {
                Property("endTime", value);
            }
        }
    
        public object? Generator
        {
            get
            {
                return Property("generator");
            }
            set
            {
                Property("generator", value);
            }
        }
    
        public object? Icon
        {
            get
            {
                return Property("icon");
            }
            set
            {
                Property("icon", value);
            }
        }
    
        public object? Image
        {
            get
            {
                return Property("image");
            }
            set
            {
                Property("image", value);
            }
        }
    
        public object? InReplyTo
        {
            get
            {
                return Property("inReplyTo");
            }
            set
            {
                Property("inReplyTo", value);
            }
        }
    
        public object? Location
        {
            get
            {
                return Property("location");
            }
            set
            {
                Property("location", value);
            }
        }
    
        public object? Preview
        {
            get
            {
                return Property("preview");
            }
            set
            {
                Property("preview", value);
            }
        }
    
        public object? Published
        {
            get
            {
                return Property("published");
            }
            set
            {
                Property("published", value);
            }
        }
    
        public object? Replies
        {
            get
            {
                return Property("replies");
            }
            set
            {
                Property("replies", value);
            }
        }
    
        public object? StartTime
        {
            get
            {
                return Property("startTime");
            }
            set
            {
                Property("startTime", value);
            }
        }
    
        public object? Summary
        {
            get
            {
                return Property("summary");
            }
            set
            {
                Property("summary", value);
            }
        }
    
        public object? Tag
        {
            get
            {
                return Property("tag");
            }
            set
            {
                Property("tag", value);
            }
        }
    
        public object? Updated
        {
            get
            {
                return Property("updated");
            }
            set
            {
                Property("updated", value);
            }
        }
    
        public object? Url
        {
            get
            {
                return Property("url");
            }
            set
            {
                Property("url", value);
            }
        }
    
        public object? To
        {
            get
            {
                return Property("to");
            }
            set
            {
                Property("to", value);
            }
        }
    
        public object? Bto
        {
            get
            {
                return Property("bto");
            }
            set
            {
                Property("bto", value);
            }
        }
    
        public object? Cc
        {
            get
            {
                return Property("cc");
            }
            set
            {
                Property("cc", value);
            }
        }
    
        public object? Bcc
        {
            get
            {
                return Property("bcc");
            }
            set
            {
                Property("bcc", value);
            }
        }
    
        public object? MediaType
        {
            get
            {
                return Property("mediaType");
            }
            set
            {
                Property("mediaType", value);
            }
        }
    
        public object? Duration
        {
            get
            {
                return Property("duration");
            }
            set
            {
                Property("duration", value);
            }
        }
    

    }
}