using Bam.Activity.Vocabulary.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    [TypeConverter(typeof(LinkTypeConverter))]
    public partial class Link
    {
        public static explicit operator string(Link link)
        {
            return link?.Href ?? "";
        }

        public static explicit operator Link(string link)
        {
            return new Link(IdHost.Default)
            {
                Href = link
            };
        }

        public override string ToString()
        {
            return this.Href!;
        }
    }
}
