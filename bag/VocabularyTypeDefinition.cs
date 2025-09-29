using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bag
{
    public class VocabularyTypeDefinition
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Notes { get; set; }
        public string Extends { get; set; }
        public List<string> Properties { get; set; } = new List<string>();
        public string Example { get; set; }
    }
}
