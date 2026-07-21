using Bam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class BamVocabularyGeneratorConfig
    {
        public BamVocabularyGeneratorConfig()
        {
            this.ConfigPath = "./BamVocabularyGenerator.config";
            this.InputsPath = "./BamVocabularyGenerator.inputs.yaml";
            this.DefinitionsDirectory = "./Generated/Definitions";
            this.CoreTypesDirectory = "./Generated/Definitions/Core";
            this.ActivityTypesDirecotory = "./Generated/Definitions/Activity";
            this.ActorTypesDirectory = "./Generated/Definitions/Actor";
            this.ObjectTypesDirectory = "./Generated/Definitions/Object";
            this.CodeDirectory = "./Generated/Code";
            this.Inputs = new FileInput(this.InputsPath);
            this.Inputs.Add("Url", "https://www.w3.org/TR/activitystreams-vocabulary/");
        }

        protected FileInput Inputs { get; set; }
        public string ConfigPath { get; set; }
        public string InputsPath { get; set; }
        public string DefinitionsDirectory { get; set; }
        public string CoreTypesDirectory { get; set; }
        public string ActivityTypesDirecotory { get; set; }
        public string ActorTypesDirectory { get; set; }
        public string ObjectTypesDirectory { get; set; }
        public string CodeDirectory { get; set; }

        public string TargetNamespace
        {
            get
            {
                return this.Inputs.Get("TargetNamespace").Or("Bam.Activity.Vocabulary");
            }
        }

        public void Save()
        {
            this.ToYamlFile(this.ConfigPath);
            this.Inputs.Save();
        }

        public static BamVocabularyGeneratorConfig Load()
        {
            return Load("./BamVocabularyGenerator.config");
        }

        public static BamVocabularyGeneratorConfig Load(string path)
        {
            if (File.Exists(path))
            {
                return path.FromYamlFile<BamVocabularyGeneratorConfig>();
            }
            else
            {
                BamVocabularyGeneratorConfig config = new BamVocabularyGeneratorConfig();
                config.Save();
                return config;
            }
        }
    }
}
