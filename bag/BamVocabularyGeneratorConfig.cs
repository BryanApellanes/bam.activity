using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bag
{
    public class BamVocabularyGeneratorConfig
    {
        public BamVocabularyGeneratorConfig()
        {
            this.InputPath = "./vocabulary.txt";
            this.OutputDirectory = "./Generated";
        }

        public string InputPath { get; set; }
        public string OutputDirectory { get; set; }
    }
}
