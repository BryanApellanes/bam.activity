using Bam;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.DependencyInjection;
using Bam.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag.Commands
{

    [ConsoleMenu("bam activity analyzer options")]
    public class Analyze : ConsoleMenuContainer
    {
        
        public Analyze(ServiceRegistry serviceRegistry) : base(serviceRegistry)
        {
        }

        public override ServiceRegistry Configure(ServiceRegistry serviceRegistry)
        {
            Configurer.ConfigureServiceRegistry(serviceRegistry);

            return base.Configure(serviceRegistry);
        }

        [ConsoleCommand("Show extends from yaml definitions")]
        [MenuItem]
        public async Task ShowExtendsFromYamlDefinitions()
        {
            VocabularyLookup vocabularyLookup = VocabularyLookup.Load(Get<BamVocabularyGeneratorConfig>().DefinitionsDirectory);
            foreach (VocabularyTypeDefinition typeDefinition in vocabularyLookup.TypeDefinitions)
            {
                Message.PrintLine("{0} : {1}", typeDefinition.Name, typeDefinition.Extends);
            }
        }

        [ConsoleCommand("Show ranges")]
        [MenuItem]
        public async Task ShowRangesfromYamlDefinitions()
        {
            VocabularyLookup vocabularyLookup = VocabularyLookup.Load(Get<BamVocabularyGeneratorConfig>().DefinitionsDirectory);
            foreach (VocabularyPropertyDefinition propertyDefinition in vocabularyLookup.PropertyDefinitions)
            {
                Message.PrintLine("{0} : {1}", propertyDefinition.Name, string.Join(", ", propertyDefinition.Range));
            }
        }

        [ConsoleCommand("Init property type map from yaml definitions")]
        [MenuItem]
        public async Task InitPropertyTypeMapFromYamlDefinitions()
        {
            FileInfo file = new FileInfo(Path.Combine(Environment.CurrentDirectory, PropertyTypeMap.FilePath));
            if (file.Exists)
            {
                Message.PrintLine("File {0} already exists", ConsoleColor.Yellow, file.FullName);
            }
            VocabularyLookup vocabularyLookup = VocabularyLookup.Load(Get<BamVocabularyGeneratorConfig>().DefinitionsDirectory);
            HashSet<string> strings = new HashSet<string>();
            foreach (VocabularyPropertyDefinition propertyDefinition in vocabularyLookup.PropertyDefinitions)
            {
                propertyDefinition.Range.Each(s => strings.Add(s));
            }
            foreach (string type in strings)
            {
                $"{type} = string\r\n".SafeAppendToFile(file.FullName);
            }
            Message.PrintLine("Wrote property file {0}", ConsoleColor.Cyan, file.FullName);
        }

        [ConsoleCommand("Show property type map")]
        [MenuItem]
        public async Task ShowPropertyTypeMap()
        {
            
            Dictionary<string, string> keyValues = PropertyTypeMap.Load();

            foreach (KeyValuePair<string, string> kvp in keyValues)
            {
                Message.PrintLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

    }
}
