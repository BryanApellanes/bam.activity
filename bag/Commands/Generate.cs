using bag;
using Bam.Console;
using Bam.DependencyInjection;
using Bam.Shell;
using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Tests.Commands
{
    [ConsoleMenu("bam activity generator options")]
    public class Generate : ConsoleMenuContainer
    {
        public Generate(ServiceRegistry serviceRegistry) : base(serviceRegistry)
        {
        }


        [ConsoleCommand("initConfig")]
        [MenuItem]
        public Task InitConfig()
        {
            throw new NotImplementedException();
        }

        [ConsoleCommand("read types")]
        [MenuItem]
        public async Task ReadTypes()
        {
            string url = Prompt.Show("Enter the url to read from (default: 'https://www.w3.org/TR/activitystreams-vocabulary/') ")
                .Or("https://www.w3.org/TR/activitystreams-vocabulary/");


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
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("read activity types")]
        [MenuItem]
        public async Task ReadActivityTypes()
        {
            string url = Prompt.Show("Enter the url to read from (default: 'https://www.w3.org/TR/activitystreams-vocabulary/') ")
                            .Or("https://www.w3.org/TR/activitystreams-vocabulary/");


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
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("read actor types")]
        [MenuItem]
        public async Task ReadActorTypes()
        {
            string url = Prompt.Show("Enter the url to read from (default: 'https://www.w3.org/TR/activitystreams-vocabulary/') ")
                            .Or("https://www.w3.org/TR/activitystreams-vocabulary/");


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
            }
            else
            {
                Message.PrintLine("Error: {0} - {1}", responnse.StatusCode, responnse.ReasonPhrase);
            }
        }

        [ConsoleCommand("read properties")]
        [MenuItem]
        public async Task ReadProperties()
        {
            string url = Prompt.Show("Enter the url to read from (default: 'https://www.w3.org/TR/activitystreams-vocabulary/') ")
                .Or("https://www.w3.org/TR/activitystreams-vocabulary/");


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
                        _ = cellText.ReadUntil("{", out string example);
                        vocabulary.Example = "{\r\n" + example.Trim();
                    }
                    else if (cellText.Equals("Notes:"))
                    {
                        vocabulary.Notes = CQ.Create(cells[i + 1]).Text().Trim();
                    }
                    else if (cellText.Equals("Extends:"))
                    {
                        vocabulary.Extends = CQ.Create(cells[i + 1])["a"].Text().Trim();
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
                                    vocabulary.Properties.Add(propText);
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
    }
}
