using Bam.Console;
using Bam.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag.Commands
{
    public class Configurer
    {
        public static void ConfigureServiceRegistry(ServiceRegistry serviceRegistry)
        {
            if (BamConsoleContext.Current.Arguments.Contains("inputFile", out string? inputFile))
            {
                if (!string.IsNullOrEmpty(inputFile))
                {
                    serviceRegistry.For<IInput>().Use(new FileInput(inputFile));
                }
            }
            else
            {
                serviceRegistry.For<IInput>().Use(() =>
                {
                    PromptInput input = new PromptInput();
                    input.SetPrompt("Url", "Enter the url to read from (default: 'https://www.w3.org/TR/activitystreams-vocabulary/') ", "https://www.w3.org/TR/activitystreams-vocabulary/");
                    return input;
                });
            }
            serviceRegistry.For<BamVocabularyGeneratorConfig>().Use(() => BamVocabularyGeneratorConfig.Load());
        }
    }
}
