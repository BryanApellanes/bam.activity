namespace Bam.Activity.Vocabulary
{
    public class Profile : Object, IProfile
    {
        public Profile(IdHost idHost) : base(idHost)
        {
            this.Property("describes", null, true);
            this.Property("Object", null, true);
        }

        public object? Describes
        {
            get
            {
                return Property("describes");
            }
            set
            {
                Property("describes", value);
            }
        }
    
        public object? Object
        {
            get
            {
                return Property("Object");
            }
            set
            {
                Property("Object", value);
            }
        }
    

    }
}