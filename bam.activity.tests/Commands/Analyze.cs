using Bam;
using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.DependencyInjection;
using Bam.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Tests.Commands
{
    [ConsoleMenu("bam activity analyzer options")]
    public class Analyze : ConsoleMenuContainer
    {
        public Analyze(ServiceRegistry serviceRegistry) : base(serviceRegistry)
        {
        }

        [ConsoleCommand("Show ranges from generated types")]
        [MenuItem]
        public async Task ShowRangesFromGeneratedTypes()
        {
            foreach (Type type in typeof(VocabularyObjectRoot).Assembly.GetTypes().Where(t => t.ExtendsType(typeof(VocabularyObjectRoot))))
            {
                Message.PrintLine("Type: {0}", type.Name);
                foreach (IProperty property in type.Construct<VocabularyObjectRoot>(new IdHost("https://example.com")).Properties)
                {
                    Message.PrintLine("  {0} : {1}", property.Name, string.Join(", ", property.Range));
                }
            }
        }

        [ConsoleCommand("Show vocabulary types")]
        [MenuItem]
        public async Task ShowVocabularyTypes()
        {
            Type[] types = typeof(VocabularyObjectRoot).Assembly.GetTypes().Where(t => t.ExtendsType(typeof(VocabularyObjectRoot))).ToArray();
            Message.PrintLine("There are {0} VocabularyObjectRoot types", ConsoleColor.Yellow, types.Length);
            foreach (Type type in types)
            {
                Message.PrintLine("{0}", type.Name);
            }
        }
    }
}
