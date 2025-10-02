using System;

namespace Bam.Activity.Vocabulary
{
    public class Activity : Object, IActivity
    {
        public Activity(IdHost idHost) : base(idHost)
        {
            this.InitProperty("actor", null, false, "Object", "Link");
            this.InitProperty("object", null, false, "Object", "Link");
            this.InitProperty("target", null, false, "Object", "Link");
            this.InitProperty("result", null, false, "Object", "Link");
            this.InitProperty("origin", null, false, "Object", "Link");
            this.InitProperty("instrument", null, false, "Object", "Link");
        }

        public Range<Object, Link>? Actor
        {
            get
            {
                return Property("actor") as Range<Object, Link>;
            }
            set
            {
                Property("actor", value);
            }
        }
    
        public Range<Object, Link>? Object
        {
            get
            {
                return Property("object") as Range<Object, Link>;
            }
            set
            {
                Property("object", value);
            }
        }
    
        public Range<Object, Link>? Target
        {
            get
            {
                return Property("target") as Range<Object, Link>;
            }
            set
            {
                Property("target", value);
            }
        }
    
        public Range<Object, Link>? Result
        {
            get
            {
                return Property("result") as Range<Object, Link>;
            }
            set
            {
                Property("result", value);
            }
        }
    
        public Range<Object, Link>? Origin
        {
            get
            {
                return Property("origin") as Range<Object, Link>;
            }
            set
            {
                Property("origin", value);
            }
        }
    
        public Range<Object, Link>? Instrument
        {
            get
            {
                return Property("instrument") as Range<Object, Link>;
            }
            set
            {
                Property("instrument", value);
            }
        }
    

    }
}