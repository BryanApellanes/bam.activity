using Bag;
using Bam;
using Bam.Console;
using Bam.DependencyInjection;
using Bam.Shell;
using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            VocabularyCodeGenerator generator = new VocabularyCodeGenerator(config);
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
                CQ dom = CQ.Create(content);

                CQ coreTypesTable = dom["#types > table"];
                CQ coreTypes = CQ.Create(coreTypesTable)["tbody"];
                Message.PrintLine("Found {0} tables", coreTypesTable.Length);
                coreTypes.Each((i, body) =>
                {
                    ParseTypeDefinition(body, vocabularyDefinitions);
                });

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
                CQ dom = CQ.Create(content);

                CQ activityTypesTable = dom["#activity-types > table"];
                CQ activityTypes = CQ.Create(activityTypesTable)["tbody"];
                activityTypes.Each((i, body) =>
                {
                    ParseTypeDefinition(body, vocabularyDefinitions);
                });

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
                CQ dom = CQ.Create(content);

                CQ actorTypesTable = dom["#actor-types > table"];
                CQ actorTypes = CQ.Create(actorTypesTable)["tbody"];
                actorTypes.Each((i, body) =>
                {
                    ParseTypeDefinition(body, vocabularyDefinitions);
                });

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
                CQ dom = CQ.Create(content);

                CQ actorTypesTable = dom["#object-types > table"];
                CQ actorTypes = CQ.Create(actorTypesTable)["tbody"];
                actorTypes.Each((i, body) =>
                {
                    ParseTypeDefinition(body, vocabularyDefinitions);
                });

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
                CQ dom = CQ.Create(content);

                //# properties > table
                CQ propertiesTable = dom["#properties > table"];
                CQ properties = CQ.Create(propertiesTable)["tbody"];
                properties.Each((i, body) =>
                {
                    ParsePropertyDefinition(body, propertyDefinitions);
                });

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
                        CQ exampleText = CQ.Create(cells[i])["pre"];
                        vocabulary.Example = exampleText.Text().Trim();
                    }
                    else if (cellText.Equals("Notes:"))
                    {
                        vocabulary.Notes = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Equals("Extends:"))
                    {
                        vocabulary.Extends = CQ.Create(cells[i + 1])["a"].First().Text().Trim();
                    }
                    else if (cellText.Equals("Properties:"))
                    {
                        string propDesc = CQ.Create(cells[i + 1]).Text().Trim();
                        if (!propDesc.StartsWith("Inherits"))
                        {
                            CQ props = CQ.Create(cells[i + 1])["a"];
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
