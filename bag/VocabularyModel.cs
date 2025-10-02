namespace Bag
{
    public class VocabularyModel
    {
        public const string VocabularyObjectRoot = "VocabularyObjectRoot";

        public VocabularyModel(VocabularyLookup lookup, VocabularyTypeDefinition definiton, Dictionary<string, string> propertyTypeMap, string nameSpace)
        {
            Lookup = lookup;
            Definition = definiton;
            Namespace = nameSpace;
            PropertyTypeMap = propertyTypeMap;
        }

        public string Namespace { get; set; }
        public VocabularyTypeDefinition Definition { get; set; }
        public VocabularyLookup Lookup { get; set; }
        public Dictionary<string, string> PropertyTypeMap { get; set; }

        public string ClassName
        {
            get
            {
                return Definition.Name;
            }
        }

        public string InterfaceList
        {
            get
            {
                return GetExtends();
            }
        }

        public string Extends
        {
            get => Definition.Extends == null || Definition.Equals("Object") ? VocabularyObjectRoot : InterfaceList;
        }

        public PropertyModel[] Properties
        {
            get => GetPropertyModels();
        }

        private string GetExtends()
        {
            if (Definition.Extends == null || Definition.Equals("Object"))
            {
                return VocabularyObjectRoot;
            }
            else
            {
                List<string> values = new List<string>();
                string[] strings = Definition.Extends.Split(",");
                if(strings.Length > 1)
                {
                    values.Add(VocabularyObjectRoot);
                    values.AddRange(strings.Select(e => $"I{e.Trim()}").ToArray());
                }
                else
                {
                    values.AddRange(strings.Select(e => $"{e.Trim()}").ToArray());
                }
                    
                values.Add($"I{ClassName}");
                return string.Join(", ", values.ToArray());
            }
        }

        private PropertyModel[] GetPropertyModels()
        {
            List<PropertyModel> properties = new List<PropertyModel>(Definition.Properties.Select(p => new PropertyModel(Lookup.GetPropertyDefinition(p), PropertyTypeMap)).ToArray());
            if (!string.IsNullOrEmpty(Definition?.Extends))
            {
                string[] extends = Definition.Extends.Split(",");
                if (extends.Length > 1) // if it extends multiple types, add properties from derived types
                {
                    foreach (string extend in extends)
                    {
                        VocabularyTypeDefinition? typeDef = Lookup.TypeDefinitions.Where(td => td.Name.Equals(extend.Trim(), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        if (typeDef != null)
                        {
                            properties.AddRange(typeDef.Properties.Select(p => new PropertyModel(Lookup.GetPropertyDefinition(p), PropertyTypeMap)).ToArray());
                        }
                    }
                }
            }
            
            return properties.ToArray();
        }
    }
}
