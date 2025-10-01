namespace Bam.Activity.Vocabulary
{
    public class Activity : Object, IActivity
    {
        public Activity(IdHost idHost) : base(idHost)
        {
            this.Property("actor", null, false);
            this.Property("object", null, false);
            this.Property("target", null, false);
            this.Property("result", null, false);
            this.Property("origin", null, false);
            this.Property("instrument", null, false);
        }

        public object? Actor
        {
            get
            {
                return Property("actor");
            }
            set
            {
                Property("actor", value);
            }
        }
    
        public object? Object
        {
            get
            {
                return Property("object");
            }
            set
            {
                Property("object", value);
            }
        }
    
        public object? Target
        {
            get
            {
                return Property("target");
            }
            set
            {
                Property("target", value);
            }
        }
    
        public object? Result
        {
            get
            {
                return Property("result");
            }
            set
            {
                Property("result", value);
            }
        }
    
        public object? Origin
        {
            get
            {
                return Property("origin");
            }
            set
            {
                Property("origin", value);
            }
        }
    
        public object? Instrument
        {
            get
            {
                return Property("instrument");
            }
            set
            {
                Property("instrument", value);
            }
        }
    

    }
}