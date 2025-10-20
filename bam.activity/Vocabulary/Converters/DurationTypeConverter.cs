using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bam.Activity.Vocabulary.Converters
{
    public class DurationTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Indicate that this converter can convert from a string
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // Implement the conversion logic from string to Duration
            if (value is string stringValue)
            {
                try
                {
                    return new Duration(stringValue);
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"Cannot convert '{stringValue}' to TimeSpan.", ex);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            // Indicate that this converter can convert to a string
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            // Implement the conversion logic from Duration to string
            if (destinationType == typeof(string) && value is Duration duration)
            {
                return duration.Value;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
