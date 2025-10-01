using Bam.Console;
using Bam.Generators;
using System.Reflection;

namespace Bag
{
    internal class VocabularyCodeGenerator
    {
        private BamVocabularyGeneratorConfig config;

        public VocabularyCodeGenerator(BamVocabularyGeneratorConfig config)
        {
            this.config = config;
        }

        public void Generate()
        {
            VocabularyLookup lookup = VocabularyLookup.Load(config.DefinitionsDirectory);
            HandlebarsEmbeddedResources handlebarsEmbeddedResources = new HandlebarsEmbeddedResources(Assembly.GetExecutingAssembly());

            foreach(VocabularyTypeDefinition typeDefinition in lookup.TypeDefinitions)
            {
                VocabularyModel model = new VocabularyModel(lookup, typeDefinition, config.TargetNamespace);
                WriteClass(handlebarsEmbeddedResources, typeDefinition, model);
                WriteInterface(handlebarsEmbeddedResources, typeDefinition, model);
            }

        }

        private void WriteClass(HandlebarsEmbeddedResources handlebarsEmbeddedResources, VocabularyTypeDefinition typeDefinition, VocabularyModel model)
        {
            string classCode = handlebarsEmbeddedResources.Render("Object", model);
            Message.PrintLine(classCode, ConsoleColor.Blue);
            FileInfo file = new FileInfo(Path.Combine(config.CodeDirectory, $"{typeDefinition.Name}.cs"));
            if (file.Exists)
            {
                file.Delete();
            }
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            File.WriteAllText(file.FullName, classCode);
        }

        private void WriteInterface(HandlebarsEmbeddedResources handlebarsEmbeddedResources, VocabularyTypeDefinition typeDefinition, VocabularyModel model)
        {
            string classCode = handlebarsEmbeddedResources.Render("Interface", model);
            Message.PrintLine(classCode, ConsoleColor.Blue);
            FileInfo file = new FileInfo(Path.Combine(config.CodeDirectory, $"I{typeDefinition.Name}.cs"));
            if (file.Exists)
            {
                file.Delete();
            }
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            File.WriteAllText(file.FullName, classCode);
        }
    }
}