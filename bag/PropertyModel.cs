using Bag;
using Bam;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class PropertyModel
    {
        public PropertyModel(VocabularyPropertyDefinition definition)
        {
            Definition = definition;
        }

        public VocabularyPropertyDefinition Definition { get; }

        public string PropertyName => Definition.Name;
        public string ClassPropertyName => PropertyName.PascalCase();
        public string IsFunctional => Definition.IsFunctional ? "true": "false";
    }
}
