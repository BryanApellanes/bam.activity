using Bam;
using Bam.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bam.Activity.Vocabulary
{
    public class Property : IProperty
    {
        public Property(string name, object? value = null, bool isFunctional = false)
        {
            Name = name;
            Value = value;
            IsFunctional = isFunctional;
        }

        public string Name { get; set; }

        public object? Value { get; set; }
        public bool IsFunctional { get; set; }
        public List<string> Range { get; set; } = new List<string>();

        public void Add(object value)
        {
            if (this.Value == null)
            {
                this.Value = value;
            }
            else if (this.Value is IList<object> list)
            {
                list.Add(value);
            }
            else
            {
                this.Value = new List<object>() { this.Value, value };
            }
        }

        public string ToJson()
        {
            return Value == null ? "null" : Value.ToJson();
        }
    }
}
