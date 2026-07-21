using Bam;
using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.DependencyInjection;
using Bam.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace bam.activity.tests.Commands
{
    [ConsoleMenu("bam activity test generator options")]
    public class Generate : ConsoleMenuContainer
    {
        public const string JsonFilesDirectory = "C:/src/repos/Server1/domains/bam-toolkit.sh/.bam/submodules/bamtk/submodules/bam.activity/bam.activity.tests/JsonFiles";
        public Generate(ServiceRegistry serviceRegistry) : base(serviceRegistry)
        {
        }

        [ConsoleCommand("Write example json files")]
        [MenuItem]
        public async Task WriteExampleJsonFiles()
        {
            foreach (Type type in typeof(VocabularyObjectRoot).Assembly.GetTypes().Where(t => t.ExtendsType(typeof(VocabularyObjectRoot))))
            {
                VocabularyObjectRoot obj = type.Construct<VocabularyObjectRoot>(IdHost.Default);
                List<string> examples = obj.Examples;
                if (examples.Count > 1)
                {
                    int num = 1;
                    foreach (string example in examples)
                    {
                        string path = Path.Combine(JsonFilesDirectory, $"{type.Name}_{num}.json");
                        File.WriteAllText(path, example);
                        num++;
                    }
                }
                else if (examples.Count == 1)
                {
                    string path = Path.Combine(JsonFilesDirectory, $"{type.Name}.json");
                    File.WriteAllText(path, examples[0]);
                }
                else
                {
                    Message.PrintLine("No examples for {0}", ConsoleColor.Yellow, type.Name);
                }
            }
        }
    }
}
