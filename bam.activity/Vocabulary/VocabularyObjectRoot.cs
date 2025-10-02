using System;
using System.Collections.Generic;
using System.Text;
using bam.Activity.Vocabulary;
using Bam;

namespace Bam.Activity.Vocabulary
{
    public abstract class VocabularyObjectRoot : IVocabularyObjectRoot
    {
        Dictionary<string, IProperty> _dictionaryOfProperties = new Dictionary<string, IProperty>();
        IdHost _idHost;

        public VocabularyObjectRoot(IdHost idHost)
        {
            this.AddProperty(new Property("@context", ActivityStreams.Context, true));
            this.AddProperty(new Property("type", this.GetType().Name, true));
        }

        protected void InitProperty(string name, object? value, bool isFunctional, params string[] range)
        {
            IProperty? property = new Property(name, value, isFunctional);
            
            if (!_dictionaryOfProperties.ContainsKey(name))
            {
                this.AddProperty(property);
            }
            else
            {
                property = _dictionaryOfProperties[name];
                if (property.IsFunctional)
                {
                    property.Value = value;
                }
                else
                {
                    property.Add(value);
                }
            }
            property.Range = new List<string>(range);
        }

        public void Property(string name, object? value)
        {
            if (_dictionaryOfProperties.ContainsKey(name))
            {
                IProperty property = _dictionaryOfProperties[name];
                if (property.IsFunctional)
                {
                    property.Value = value;
                }
                else
                {
                    property.Add(value);
                }
            }
        }

        public IEnumerable<IProperty> Properties
        {
            get => _dictionaryOfProperties.Values;
        }

        public object? Property(string name)
        {
            if(_dictionaryOfProperties.TryGetValue(name, out IProperty? prop))
            {
                return prop.Value;
            }
            throw new Exception($"Property '{name}' not found.");
        }

        public string ToJson()
        {
            return _dictionaryOfProperties.ToJson();
        }

        private void AddProperty(IProperty property)
        {
            if (!_dictionaryOfProperties.ContainsKey(property.Name))
            {
                _dictionaryOfProperties.Add(property.Name, property);
            }
        }
    }
}
