using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity  
{
    public interface IVocabularyObjectRoot : IJsonable
    {
        IEnumerable<IProperty> Properties { get; }

        //void Property(string name, object value, bool isFunctional = false);
        T Property<T>(string name);
        void Property(string name, object value);
    }
}
