using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity
{ 
    public interface IProperty
    {
        string Name { get; set; }
        string Value { get; set; }

        string ToJson();
    }
}
