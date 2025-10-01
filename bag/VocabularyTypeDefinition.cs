using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class VocabularyTypeDefinition
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Notes { get; set; }
        public string Extends { get; set; }
        public HashSet<string> Properties { get; set; } = new HashSet<string>();
        public string Example { get; set; }
    }
}
