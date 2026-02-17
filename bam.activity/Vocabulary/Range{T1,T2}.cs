using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    public class Range<T1, T2> : Range<T1>
    {
        private int _activeSlot;
        private T2 _value2 = default!;

        public static implicit operator T1(Range<T1, T2> range) => range.Value;

        public static implicit operator T2(Range<T1, T2> range) => range.Value2;

        public new T1 Value
        {
            get => base.Value;
            set
            {
                base.Value = value;
                if (value != null)
                {
                    _activeSlot = 1;
                }
            }
        }

        public T2 Value2
        {
            get => _value2;
            set
            {
                _value2 = value;
                if (value != null)
                {
                    _activeSlot = 2;
                }
            }
        }

        public new bool HasValue => _activeSlot == 1;

        public bool HasValue2 => _activeSlot == 2;

        public object GetActiveValue()
        {
            return _activeSlot switch
            {
                1 => Value!,
                2 => Value2!,
                _ => null!
            };
        }

        public Type GetActiveType()
        {
            return _activeSlot switch
            {
                1 => typeof(T1),
                2 => typeof(T2),
                _ => null!
            };
        }

        public void Match(Action<T1> onT1, Action<T2> onT2)
        {
            switch (_activeSlot)
            {
                case 1:
                    onT1(Value);
                    break;
                case 2:
                    onT2(Value2);
                    break;
            }
        }

        public TResult Match<TResult>(Func<T1, TResult> onT1, Func<T2, TResult> onT2)
        {
            return _activeSlot switch
            {
                1 => onT1(Value),
                2 => onT2(Value2),
                _ => default!
            };
        }

        public static Range<T1, T2> Of(T1 value)
        {
            return new Range<T1, T2> { Value = value };
        }

        public static Range<T1, T2> Of(T2 value)
        {
            return new Range<T1, T2> { Value2 = value };
        }
    }
}
