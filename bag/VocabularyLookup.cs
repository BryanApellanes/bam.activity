using Bam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bag
{
    public class VocabularyLookup
    {
        Dictionary<string, VocabularyTypeDefinition> _typeDefinitions = new Dictionary<string, VocabularyTypeDefinition>();
        Dictionary<string, VocabularyPropertyDefinition> _propertyDefinitions = new Dictionary<string, VocabularyPropertyDefinition>();

        public VocabularyLookup() { }

        public VocabularyTypeDefinition[] TypeDefinitions => _typeDefinitions.Values.ToArray();

        public VocabularyPropertyDefinition? GetPropertyDefinition(string propertyName)
        {
            if (_propertyDefinitions.ContainsKey(propertyName))
            {
                return _propertyDefinitions[propertyName];
            }
            else if(TypeDefinitions.Where(td=> td.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
            {
                return new VocabularyPropertyDefinition() { Name = propertyName, IsFunctional = true };
            }
            else
            {
                throw new KeyNotFoundException($"The property definition '{propertyName}' was not found.");
            }
        }

        public static VocabularyLookup Load(string definitionRoot)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(definitionRoot);
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException($"The directory '{definitionRoot}' does not exist.");
            }
            VocabularyLookup lookup = new VocabularyLookup();
            foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
            {
                if (!subDirectory.Name.Equals("properties"))
                {
                    foreach (FileInfo file in subDirectory.GetFiles("*.yaml"))
                    {
                        VocabularyTypeDefinition? typeDef = file.FullName.FromYamlFile<VocabularyTypeDefinition>();
                        if (typeDef != null && !string.IsNullOrEmpty(typeDef.Name))
                        {
                            lookup._typeDefinitions[typeDef.Name] = typeDef;
                        }
                    }
                }
                else
                {
                    foreach (FileInfo file in subDirectory.GetFiles("*.yaml"))
                    {
                        VocabularyPropertyDefinition? propDef = file.FullName.FromYamlFile<VocabularyPropertyDefinition>();
                        if (propDef != null && !string.IsNullOrEmpty(propDef.Name))
                        {
                            lookup._propertyDefinitions[propDef.Name] = propDef;
                        }
                    }
                }
            }

            return lookup;
        }
    }
}
