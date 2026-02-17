using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    public class Range<T1>
    {
        public static implicit operator T1(Range<T1> range) => range.Value;
        public T1 Value { get; set; } = default!;
        public bool HasValue => Value != null;
    }
}
