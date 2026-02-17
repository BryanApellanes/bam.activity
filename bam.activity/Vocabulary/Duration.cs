using Bam.Activity.Vocabulary.Converters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// A class used to convert between ISO 8601 time duration string representations to .NET TimeSpan instances.
    /// </summary>
    [TypeConverter(typeof(DurationTypeConverter))]
    public class Duration
    {
        public static explicit operator string(Duration duration)
        {
            return duration.Value;
        }

        public static explicit operator TimeSpan(Duration duration)
        {
            return XmlConvert.ToTimeSpan(duration.Value);
        }

        public Duration() { }

        public Duration(string value)
        {
            this.Value = value;
        }

        public Duration(TimeSpan value)
        {
            this.Value = XmlConvert.ToString(value) ;
        }

        public string Value { get; set; } = null!;

        public override string ToString()
        {
            return Value;
        }
    }
}
