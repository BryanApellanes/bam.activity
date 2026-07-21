using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity
{ 
    public interface IProperty
    {
        string Name { get; set; }
        object? Value { get; set; }
        bool IsFunctional { get; set; }
        List<string> Range { get; set; }

        void Add(object value);
        
        /// <summary>
        /// When implemented, returns a JSON representation of the value of this property.
        /// </summary>
        /// <returns></returns>
        string ToJson();
    }
}
