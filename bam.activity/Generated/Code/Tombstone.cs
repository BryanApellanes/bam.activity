using System;

namespace Bam.Activity.Vocabulary
{
    public class Tombstone : Object, ITombstone
    {
        public Tombstone(IdHost idHost) : base(idHost)
        {
            this.InitProperty("formerType", null, false, "Object");
            this.InitProperty("deleted", null, true, "xsd:dateTime");
        }

        public Range<Object>? FormerType
        {
            get
            {
                return Property("formerType") as Range<Object>;
            }
            set
            {
                Property("formerType", value);
            }
        }
    
        public Range<DateTime>? Deleted
        {
            get
            {
                return Property("deleted") as Range<DateTime>;
            }
            set
            {
                Property("deleted", value);
            }
        }
    

    }
}