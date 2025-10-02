using System;

namespace Bam.Activity.Vocabulary
{
    public class Profile : Object, IProfile
    {
        public Profile(IdHost idHost) : base(idHost)
        {
            this.InitProperty("describes", null, true, "Object");
        }

        public Range<Object>? Describes
        {
            get
            {
                return Property("describes") as Range<Object>;
            }
            set
            {
                Property("describes", value);
            }
        }
    

    }
}