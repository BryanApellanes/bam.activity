using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity  
{
    public interface IObject
    {
        string ToJson();  
        IEnumerable<IProperty> Properties { get; }

        void Property(string name, object value, bool isFunctional = false);
        object? Property(string name);
    }
}
