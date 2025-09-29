using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace bag
{
    public class VocabularyPropertyDefinition
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Notes { get; set; }
        public string Domain { get; set; }
        public List<string> Range { get; set; } = new List<string>();

        public string SubPropertyOf { get; set; }
    }
}
