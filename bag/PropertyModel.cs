using Bam;

namespace Bag
{
    public class PropertyModel
    {
        public PropertyModel(VocabularyPropertyDefinition definition, Dictionary<string, string> propertyTypeMap)
        {
            Definition = definition;
            if(definition.Range.Count > 0)
            {
                RangeParams = string.Join(", ", definition.Range.Select(r => $"\"{r}\"").ToArray());
            }
            else
            {
                RangeParams = "string.Empty";
            }

            if (Definition.Range.Count == 0)
            {
                this.ReturnType = "Object";
            }
            else if (Definition.Range.Count == 1)
            {
                if (propertyTypeMap.ContainsKey(Definition.Range[0]))
                {
                    this.ReturnType = $"{propertyTypeMap[Definition.Range[0]]}";
                }
                else
                {
                    this.ReturnType = "Object";
                }
            }
            else
            {
                HashSet<string> types = new HashSet<string>();
                foreach (string r in Definition.Range)
                {
                    if (propertyTypeMap.ContainsKey(r))
                    {
                        string t = propertyTypeMap[r];
                        types.Add(t);
                    }
                    else
                    {
                        types.Add("Object");
                    }
                }
                if (types.Count == 1)
                {
                    this.ReturnType = types.First();
                }
                else
                {
                    this.ReturnType = $"Range<{string.Join(", ", types.ToArray())}>";
                }
            }
        }

        public VocabularyPropertyDefinition Definition { get; }
        public Dictionary<string, string> PropertyTypeMap { get; set; }
        public string Notes => Definition.Notes != null ? Definition.Notes.Replace("\n", " ").Replace("\r", " ").Replace("\"", "'") : string.Empty;
        public string PropertyName => Definition.Name;
        public string ClassPropertyName => PropertyName.PascalCase();
        public string IsFunctional => Definition.IsFunctional ? "true": "false";

        public string RangeParams { get; set; }
        public string ReturnType { get; set; }

        public override string ToString()
        {
            return PropertyName;
        }
    }
}
