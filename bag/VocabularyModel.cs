using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class VocabularyModel
    {
        public VocabularyModel(VocabularyLookup lookup, VocabularyTypeDefinition definiton, string nameSpace)
        {
            Lookup = lookup;
            Definition = definiton;
            Namespace = nameSpace;
        }

        public string Namespace { get; set; }
        public VocabularyTypeDefinition Definition { get; set; }
        public VocabularyLookup Lookup { get; set; }

        public string ClassName
        {
            get
            {
                return Definition.Name;
            }
        }

        public string Extends
        {
            get => Definition.Extends == null || Definition.Equals("Object") ? "ObjectBase": Definition.Extends;
        }

        public PropertyModel[] Properties
        {
            get => Definition.Properties.Select(p => new PropertyModel(Lookup.GetPropertyDefinition(p))).ToArray();
        }
    }
}
