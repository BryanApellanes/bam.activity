namespace Bam.Activity.Vocabulary
{
    public class Question : IntransitiveActivity, IQuestion
    {
        public Question(IdHost idHost) : base(idHost)
        {
            this.Property("oneOf", null, false);
            this.Property("anyOf", null, false);
            this.Property("closed", null, false);
            this.Property("IntransitiveActivity", null, true);
        }

        public object? OneOf
        {
            get
            {
                return Property("oneOf");
            }
            set
            {
                Property("oneOf", value);
            }
        }
    
        public object? AnyOf
        {
            get
            {
                return Property("anyOf");
            }
            set
            {
                Property("anyOf", value);
            }
        }
    
        public object? Closed
        {
            get
            {
                return Property("closed");
            }
            set
            {
                Property("closed", value);
            }
        }
    
        public object? IntransitiveActivity
        {
            get
            {
                return Property("IntransitiveActivity");
            }
            set
            {
                Property("IntransitiveActivity", value);
            }
        }
    

    }
}