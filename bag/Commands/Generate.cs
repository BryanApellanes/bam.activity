using Bam;
using Bam.Console;
using Bam.DependencyInjection;
using Bam.Generators;
using Bam.Shell;
using CsQuery;
using System.Reflection;

namespace Bag.Commands
{
    [ConsoleMenu("bam activity generator options")]
    public class Generate : ConsoleMenuContainer
    {
        public Generate(ServiceRegistry serviceRegistry) : base(serviceRegistry)
        {
        }

        public override ServiceRegistry Configure(ServiceRegistry serviceRegistry)
        {
            Configurer.ConfigureServiceRegistry(serviceRegistry);

            return base.Configure(serviceRegistry);
        }

        [ConsoleCommand("initConfig")]
        [MenuItem]
        public async Task InitConfig()
        {
            BamVocabularyGeneratorConfig config = new BamVocabularyGeneratorConfig();
            config.Save();
            Message.PrintLine("Config file created at {0}", new FileInfo(config.ConfigPath).FullName);
        }

        [ConsoleCommand("Generate vocabulary code")]
        [MenuItem]
        public async Task GenerateCode()
        {
            BamVocabularyGeneratorConfig config = Get<BamVocabularyGeneratorConfig>();
            VocabularyCodeGenerator generator = new VocabularyCodeGenerator
            (
                config, 
                VocabularyLookup.Load(config.DefinitionsDirectory), 
                new HandlebarsEmbeddedResources(Assembly.GetExecutingAssembly())
            );
            generator.Generate();
        }

        [ConsoleCommand("Download all")]
        [MenuItem]
        public async Task DownloadAll()
        {
            Task.WaitAll
            (
                DownloadCoreTypes(), 
                DownloadActivityTypes(),
                DownloadActorTypes(),
                DownloadObjectTypes(),
                DownloadProperties()
            );
        }


        [ConsoleCommand("Download html content")]
        [MenuItem]
        public async Task DownloadHtmlContent()
        {
            BamVocabularyGeneratorConfig config = Get<BamVocabularyGeneratorConfig>();
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyTypeDefinition> vocabularyDefinitions = new List<VocabularyTypeDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                string[] segments = url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                string fileName = segments[segments.Length - 1];
                FileInfo file = new FileInfo(Path.Combine(config.DefinitionsDirectory, fileName + ".html"));
                if (file.Exists)
                {
                    File.Delete(file.FullName);
                }
                string? directoryName = file.DirectoryName;
                if (directoryName != null && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                File.WriteAllText(file.FullName, content);
                Message.PrintLine("Wrote {0}", file.FullName);
            }
        }

        [ConsoleCommand("Download core types")]
        [MenuItem]
        public async Task DownloadCoreTypes()
        {
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyTypeDefinition> vocabularyDefinitions = new List<VocabularyTypeDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                vocabularyDefinitions.AddRange(ParseTypeDefinitions(content, "#types > table"));

                foreach (VocabularyTypeDefinition definition in vocabularyDefinitions)
                {
                    Message.PrintLine("{0}", definition.ToYaml());
                    Message.PrintLine("-----");
                }
                SaveVocabularyTypeDefinitions(vocabularyDefinitions, Get<BamVocabularyGeneratorConfig>().CoreTypesDirectory);
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("Download activity types")]
        [MenuItem]
        public async Task DownloadActivityTypes()
        {
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyTypeDefinition> vocabularyDefinitions = new List<VocabularyTypeDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                vocabularyDefinitions.AddRange(ParseTypeDefinitions(content, "#activity-types > table"));

                foreach (VocabularyTypeDefinition definition in vocabularyDefinitions)
                {
                    Message.PrintLine("{0}", definition.ToYaml());
                    Message.PrintLine("-----");
                }
                SaveVocabularyTypeDefinitions(vocabularyDefinitions, Get<BamVocabularyGeneratorConfig>().ActivityTypesDirecotory);
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("Download actor types")]
        [MenuItem]
        public async Task DownloadActorTypes()
        {
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyTypeDefinition> vocabularyDefinitions = new List<VocabularyTypeDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                vocabularyDefinitions.AddRange(ParseTypeDefinitions(content, "#actor-types > table"));

                foreach (VocabularyTypeDefinition definition in vocabularyDefinitions)
                {
                    Message.PrintLine("{0}", definition.ToYaml());
                    Message.PrintLine("-----");
                }

                SaveVocabularyTypeDefinitions(vocabularyDefinitions, Get<BamVocabularyGeneratorConfig>().ActorTypesDirectory);
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("Download object types")]
        [MenuItem]
        public async Task DownloadObjectTypes()
        {
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyTypeDefinition> vocabularyDefinitions = new List<VocabularyTypeDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                vocabularyDefinitions.AddRange(ParseTypeDefinitions(content, "#object-types > table"));

                foreach (VocabularyTypeDefinition definition in vocabularyDefinitions)
                {
                    Message.PrintLine("{0}", definition.ToYaml());
                    Message.PrintLine("-----");
                }

                SaveVocabularyTypeDefinitions(vocabularyDefinitions, Get<BamVocabularyGeneratorConfig>().ObjectTypesDirectory);
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("Downlaod properties")]
        [MenuItem]
        public async Task DownloadProperties()
        {
            IInput input = Get<IInput>();
            string url = input.Get("Url");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage responnse = await client.GetAsync(url);
            if (responnse.IsSuccessStatusCode)
            {
                List<VocabularyPropertyDefinition> propertyDefinitions = new List<VocabularyPropertyDefinition>();

                string content = await responnse.Content.ReadAsStringAsync();
                propertyDefinitions.AddRange(ParsePropertyDefinitions(content));

                foreach (VocabularyPropertyDefinition definition in propertyDefinitions)
                {
                    Message.PrintLine("{0}", definition.ToYaml());
                    Message.PrintLine("-----");
                }
                SaveVocabularyPropertyDefinitions(propertyDefinitions);
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        /// <summary>
        /// Reads the vocabulary type definitions from the tables matched by <paramref name="tableSelector"/>
        /// (one definition per tbody) in an ActivityStreams vocabulary page.
        /// </summary>
        public static List<VocabularyTypeDefinition> ParseTypeDefinitions(string html, string tableSelector)
        {
            List<VocabularyTypeDefinition> definitions = new List<VocabularyTypeDefinition>();
            CQ dom = CQ.Create(html);
            CQ tables = dom[tableSelector];
            CQ bodies = CQ.Create(tables)["tbody"];
            bodies.Each((i, body) =>
            {
                ParseTypeDefinition(body, definitions);
            });
            return definitions;
        }

        /// <summary>
        /// Reads the vocabulary property definitions from the properties tables (one definition per tbody)
        /// in an ActivityStreams vocabulary page.
        /// </summary>
        public static List<VocabularyPropertyDefinition> ParsePropertyDefinitions(string html)
        {
            List<VocabularyPropertyDefinition> definitions = new List<VocabularyPropertyDefinition>();
            CQ dom = CQ.Create(html);
            CQ tables = dom["#properties > table"];
            CQ bodies = CQ.Create(tables)["tbody"];
            bodies.Each((i, body) =>
            {
                ParsePropertyDefinition(body, definitions);
            });
            return definitions;
        }

        private static void ParseTypeDefinition(IDomObject body, List<VocabularyTypeDefinition> coreTypeDefinitions)
        {
            VocabularyTypeDefinition vocabulary = new VocabularyTypeDefinition();
            CQ definition = CQ.Create(body)["dfn"];
            string definitionText = definition.Text().Trim();
            if (!string.IsNullOrEmpty(definitionText))
            {
                if (definitionText.Equals("Relationship"))
                {
                    definitionText = "RelationshipDescriptor"; // Relationship has a property called relationship which causes issues
                }
                vocabulary.Name = definitionText;
            }
            CQ rows = CQ.Create(body)["tr"];
            rows.Each((j, row) =>
            {
                CQ cells = CQ.Create(row)["td"];
                for (int i = 0; i < cells.Length; i++)
                {
                    string cellText = CQ.Create(cells[i]).Text();

                    if (cellText.Equals("URI:"))
                    {
                        vocabulary.Uri = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Trim().StartsWith("Example"))
                    {
                        CQ exampleText = CQ.Create(cells[i])["pre"].Each(d=> vocabulary.Examples.Add(CQ.Create(d).Text().Trim()));
                    }
                    else if (cellText.Equals("Notes:"))
                    {
                        vocabulary.Notes = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Equals("Extends:"))
                    {
                        vocabulary.Extends = string.Join(", ", CQ.Create(cells[i + 1])["a"].Select(d => d.InnerText).ToArray());
                    }
                    else if (cellText.Equals("Properties:"))
                    {
                        string propDesc = CQ.Create(cells[i + 1]).Text().Trim();
                        if (!propDesc.StartsWith("Inherits"))
                        {
                            CQ props = CQ.Create(CQ.Create(cells[i + 1])["p:first-of-type"])["a"];
                            props.Each((k, prop) =>
                            {
                                string propText = CQ.Create(prop).Text();
                                if (!string.IsNullOrEmpty(propText))
                                {
                                    if (!vocabulary.Properties.Any(p => p.Equals(propText, StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        vocabulary.Properties.Add(propText);
                                    }
                                }
                            });
                        }
                    }
                }
            });
            coreTypeDefinitions.Add(vocabulary);
        }

        private static void ParsePropertyDefinition(IDomObject body, List<VocabularyPropertyDefinition> typePropertyDefinition)
        {
            VocabularyPropertyDefinition vocabulary = new VocabularyPropertyDefinition();
            CQ definition = CQ.Create(body)["dfn"];
            string definitionText = definition.Text().Trim();
            if (!string.IsNullOrEmpty(definitionText))
            {
                vocabulary.Name = definitionText;
            }
            CQ rows = CQ.Create(body)["tr"];
            rows.Each((j, row) =>
            {
                CQ cells = CQ.Create(row)["td"];
                for (int i = 0; i < cells.Length; i++)
                {
                    string cellText = CQ.Create(cells[i]).Text();
                    if (cellText.Equals("URI:"))
                    {
                        vocabulary.Uri = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Equals("Notes:"))
                    {
                        vocabulary.Notes = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Equals("Domain:"))
                    {
                        vocabulary.Domain = CQ.Create(cells[i + 1])["a"].Text().Trim();
                    }
                    else if (cellText.Equals("Functional:"))
                    {
                        vocabulary.IsFunctional = CQ.Create(cells[i + 1]).Text().Trim().Equals("True", StringComparison.InvariantCultureIgnoreCase);
                    }
                    else if (cellText.Equals("Range:"))
                    {
                        CQ range = CQ.Create(cells[i + 1])["a"];
                        if(range.Length > 0)
                        {
                            ReadRange(vocabulary, range);
                        }
                        else
                        {
                            range = CQ.Create(cells[i + 1])["code"];
                            if(range.Length > 0)
                            {
                                ReadRange(vocabulary, range);
                            }
                        }
                        
                    }
                }
            });
            typePropertyDefinition.Add(vocabulary);
        }

        private static void ReadRange(VocabularyPropertyDefinition vocabulary, CQ range)
        {
            range.Each((k, r) =>
            {
                string rangeText = CQ.Create(r).Text();
                if (!string.IsNullOrEmpty(rangeText))
                {
                    vocabulary.Range.Add(rangeText);
                }
            });
        }

        private void SaveVocabularyTypeDefinitions(List<VocabularyTypeDefinition> vocabularyTypeDefinitions, string directory)
        {
            foreach (VocabularyTypeDefinition vocabularyTypeDefinition in vocabularyTypeDefinitions)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string filePath = Path.Combine(directory, vocabularyTypeDefinition.Name + ".yaml");
                File.WriteAllText(filePath, vocabularyTypeDefinition.ToYaml());
                Message.PrintLine("Wrote {0}", filePath);
            }
        }

        private void SaveVocabularyPropertyDefinitions(List<VocabularyPropertyDefinition> vocabularyPropertyDefinitions)
        {
            foreach(VocabularyPropertyDefinition vocabularyPropertyDefinition in vocabularyPropertyDefinitions)
            {
                string outputDirectory = Get<BamVocabularyGeneratorConfig>().DefinitionsDirectory;
                string propertyDirectory = Path.Combine(outputDirectory, "properties");
                if (!Directory.Exists(propertyDirectory))
                {
                    Directory.CreateDirectory(propertyDirectory);
                }
                string filePath = Path.Combine(propertyDirectory, vocabularyPropertyDefinition.Name + ".yaml");
                File.WriteAllText(filePath, vocabularyPropertyDefinition.ToYaml());
                Message.PrintLine("Wrote {0}", filePath);
            }
        }
    }
}
