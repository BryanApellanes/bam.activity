using System;

namespace Bam.Activity.Vocabulary
{
    public class Question : IntransitiveActivity, IQuestion
    {
        public Question(IdHost idHost) : base(idHost)
        {
            this.InitProperty("oneOf", null, false, "Object", "Link");
            this.InitProperty("anyOf", null, false, "Object", "Link");
            this.InitProperty("closed", null, false, "Object", "Link");
        }

        public Range<Object, Link>? OneOf
        {
            get
            {
                return Property("oneOf") as Range<Object, Link>;
            }
            set
            {
                Property("oneOf", value);
            }
        }
    
        public Range<Object, Link>? AnyOf
        {
            get
            {
                return Property("anyOf") as Range<Object, Link>;
            }
            set
            {
                Property("anyOf", value);
            }
        }
    
        public Range<Object, Link>? Closed
        {
            get
            {
                return Property("closed") as Range<Object, Link>;
            }
            set
            {
                Property("closed", value);
            }
        }
    

    }
}