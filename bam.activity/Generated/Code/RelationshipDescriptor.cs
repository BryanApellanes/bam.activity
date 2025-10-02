using System;

namespace Bam.Activity.Vocabulary
{
    public class RelationshipDescriptor : Object, IRelationshipDescriptor
    {
        public RelationshipDescriptor(IdHost idHost) : base(idHost)
        {
            this.InitProperty("subject", null, true, "Link", "Object");
            this.InitProperty("object", null, false, "Object", "Link");
            this.InitProperty("relationship", null, false, "Object");
        }

        public Range<Link, Object>? Subject
        {
            get
            {
                return Property("subject") as Range<Link, Object>;
            }
            set
            {
                Property("subject", value);
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
    
        public Range<Object>? Relationship
        {
            get
            {
                return Property("relationship") as Range<Object>;
            }
            set
            {
                Property("relationship", value);
            }
        }
    

    }
}