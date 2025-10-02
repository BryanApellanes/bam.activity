using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    public class Range<T1, T2> : Range<T1>
    {
        public static implicit operator T1(Range<T1, T2> range) => range.Value;
        public static implicit operator T2(Range<T1, T2> range) => range.Value2;
        public T2 Value2 { get; set; }
    }
}
