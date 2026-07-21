using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A Profile is a content object that describes another Object, typically used to describe Actor Type objects. The describes property is used to reference the object being described by the profile.
    /// </summary>
    public partial class Profile : Object, IProfile
    {
        public Profile(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("describes", null, true, "Object");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Profile"",
  ""summary"": ""Sally's Profile"",
  ""describes"": {
    ""type"": ""Person"",
    ""name"": ""Sally Smith""
  }
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// On a Profile object, the             describes property identifies the object described by the Profile.
        /// </summary>
        public Object? Describes
        {
            get
            {
                return Property<Object>("describes");
            }
            set
            {
                Property("describes", value);
            }
        }


    }
}