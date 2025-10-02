using Bam;
using Bam.Console;
using Bam.Generators;
using System.Reflection;

namespace Bag
{
    public class VocabularyCodeGenerator
    {
        public VocabularyCodeGenerator(BamVocabularyGeneratorConfig config, VocabularyLookup vocabularyLookup, ITemplateRenderer templateRenderer)
        {
            this.Config = config;
            this.VocabularyLookup = vocabularyLookup;
            this.TemplateRenderer = templateRenderer;
        }

        public BamVocabularyGeneratorConfig Config { get; set; }
        public VocabularyLookup VocabularyLookup { get; set; }
        public ITemplateRenderer TemplateRenderer { get; set; }

        public void Generate()
        {
            VocabularyLookup lookup = VocabularyLookup.Load(Config.DefinitionsDirectory);
            HandlebarsEmbeddedResources handlebarsEmbeddedResources = new HandlebarsEmbeddedResources(Assembly.GetExecutingAssembly());
            Dictionary<string, string> propertyTypeMap = PropertyTypeMap.Load();

            foreach (VocabularyTypeDefinition typeDefinition in lookup.TypeDefinitions)
            {
                VocabularyModel model = new VocabularyModel(lookup, typeDefinition, propertyTypeMap, Config.TargetNamespace);
                WriteClass(typeDefinition, model);
                WriteInterface(typeDefinition, model);
            }

        }

        private void WriteClass(VocabularyTypeDefinition typeDefinition, VocabularyModel model)
        {
            string classCode = TemplateRenderer.Render("Object", model);
            Message.PrintLine(classCode, ConsoleColor.Blue);
            FileInfo file = new FileInfo(Path.Combine(Config.CodeDirectory, $"{typeDefinition.Name}.cs"));
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

        private void WriteInterface(VocabularyTypeDefinition typeDefinition, VocabularyModel model)
        {
            string classCode = TemplateRenderer.Render("Interface", model);
            Message.PrintLine(classCode, ConsoleColor.Blue);
            FileInfo file = new FileInfo(Path.Combine(Config.CodeDirectory, $"I{typeDefinition.Name}.cs"));
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
