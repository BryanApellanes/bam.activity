using Bam;

namespace Bag
{
    public class PropertyModel
    {
        public PropertyModel(VocabularyPropertyDefinition definition, Dictionary<string, string> propertyTypeMap)
        {
            Definition = definition;
            if (Definition.Range.Count == 0)
            {
                this.Range = "\"\"";
                this.ReturnType = "Object";
            }
            else if (Definition.Range.Count == 1)
            {
                this.Range = $"\"{Definition.Range[0]}\"";
                if (propertyTypeMap.ContainsKey(Definition.Range[0]))
                {
                    this.ReturnType = $"Range<{propertyTypeMap[Definition.Range[0]]}>";
                }
                else
                {
                    this.ReturnType = "Object";
                }
            }
            else
            {
                this.Range = string.Join(", ", Definition.Range.Select(v => $"\"{v}\""));
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
                this.ReturnType = $"Range<{string.Join(", ", types.ToArray())}>";
            }
        }

        public VocabularyPropertyDefinition Definition { get; }
        public Dictionary<string, string> PropertyTypeMap { get; set; }

        public string PropertyName => Definition.Name;
        public string ClassPropertyName => PropertyName.PascalCase();
        public string Range { get; set; }
        public string IsFunctional => Definition.IsFunctional ? "true": "false";

        public string ReturnType { get; set; }
    }
}
