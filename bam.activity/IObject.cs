using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity  
{
    public interface IObject
    {
        string ToJson();  
        IEnumerable<IProperty> Properties { get; set; }
    }
}
