using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents a question being asked. Question objects are an extension of IntransitiveActivity. That is, the Question object is an Activity, but the direct object is the question itself and therefore it would not contain an                 object property.                                               Either of the anyOf and                 oneOf properties MAY be used to express possible answers, but a Question object MUST NOT have both properties.
    /// </summary>
    public partial class Question : IntransitiveActivity, IQuestion
    {
        public Question(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);
            this.InitProperty("oneOf", null, false, "Object", "Link");
            this.InitProperty("anyOf", null, false, "Object", "Link");
            this.InitProperty("closed", null, false, "Object", "Link");

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Question"",
  ""name"": ""What is the answer?"",
  ""oneOf"": [
    {
      ""type"": ""Note"",
      ""name"": ""Option A""
    },
    {
      ""type"": ""Note"",
      ""name"": ""Option B""
    }
  ]
}");
            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Question"",
  ""name"": ""What is the answer?"",
  ""closed"": ""2016-05-10T00:00:00Z""
}");
            this.EndCtorInit(idHost);
        }

        /// <summary>
        /// Identifies an exclusive option for a Question. Use of             oneOf implies that the Question can have only a single answer. To indicate that a Question can have multiple answers, use             anyOf.
        /// </summary>
        public Range<Object, Link>? OneOf
        {
            get
            {
                return Property<Range<Object, Link>>("oneOf");
            }
            set
            {
                Property("oneOf", value);
            }
        }

        /// <summary>
        /// Identifies an inclusive option for a Question. Use of             anyOf implies that the Question can have multiple answers. To indicate that a Question can have only one answer, use             oneOf.
        /// </summary>
        public Range<Object, Link>? AnyOf
        {
            get
            {
                return Property<Range<Object, Link>>("anyOf");
            }
            set
            {
                Property("anyOf", value);
            }
        }

        /// <summary>
        /// Indicates that a question has been closed, and answers are no longer accepted.
        /// </summary>
        public Range<Object, Link>? Closed
        {
            get
            {
                return Property<Range<Object, Link>>("closed");
            }
            set
            {
                Property("closed", value);
            }
        }


    }
}