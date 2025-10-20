using bam.Activity.Vocabulary;
using Bam;
using Bam.Data.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public abstract class VocabularyObjectRoot : IVocabularyObjectRoot
    {
        Dictionary<string, IProperty> _properties = new Dictionary<string, IProperty>();
        IdHost _idHost;
        List<string> _examples = new List<string>();

        public VocabularyObjectRoot(IdHost idHost)
        {
            this._idHost = idHost;
            this.AddProperty(new Property("@context", ActivityStreams.Context, true));
            this.AddProperty(new Property("type", this.GetType().Name, true));
            this.AddProperty(new Property("id", null, true));
        }

        protected void Example(string example)
        {
            _examples.Add(example);
        }

        public string Example(int index = 0)
        {
            return _examples.Count > index ? _examples[index] : string.Empty;
        }

        public List<string> Examples
        {
            get => _examples;
        }

        /// <summary>
        /// Performs initialization logic before properties are initialized.
        /// </summary>
        /// <remarks>This method is intended to be overridden in derived classes to provide custom
        /// initialization logic.  It is called during the construction process, prior to the initialization of
        /// properties.</remarks>
        /// <param name="args">An array of arguments that can be used to customize the initialization process. The specific usage of these
        /// arguments is determined by the derived class.</param>
        protected virtual void StartCtorInit(params object[] args)
        {
            // Override in derived classes to perform initialization before properties are initialized.
        }

        /// <summary>
        /// Completes the initialization process after the constructor has set up the initial state.
        /// </summary>
        /// <remarks>This method is intended to be overridden in derived classes to perform additional
        /// setup or initialization  after the constructor has initialized the object's properties. The base
        /// implementation does nothing.</remarks>
        /// <param name="args">An optional array of arguments that can be used to customize the initialization process. The specific usage
        /// of these arguments is determined by derived classes.</param>
        protected virtual void EndCtorInit(params object[] args)
        {
            // Override in derived classes to perform initialization after properties are initialized.
        }

        protected void InitProperty(string name, object? value, bool isFunctional, params string[] range)
        {
            IProperty? property = new Property(name, value, isFunctional);
            
            if (!_properties.ContainsKey(name))
            {
                this.AddProperty(property);
            }
            else
            {
                property = _properties[name];
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
            if (_properties.ContainsKey(name))
            {
                IProperty property = _properties[name];
                if (property.IsFunctional)
                {
                    property.Value = value;
                }
                else if (value is JArray jArray)
                {
                    foreach (JToken item in jArray)
                    {
                        property.Add(item);
                    }
                }
                else
                {
                    property.Add(value);
                }
            }
        }

        public IEnumerable<IProperty> Properties
        {
            get => _properties.Values;
        }

        public List<string> PropertyNames
        {
            get => _properties.Keys.ToList();
        }

        public object? Property(string name)
        {
            if (_properties.TryGetValue(name, out IProperty? prop))
            {
                return prop.Value;
            }
            throw new Exception($"Property '{name}' not found.");
        }

        public T Property<T>(string name)
        {
            if (_properties.TryGetValue(name, out IProperty? prop))
            {
                if(prop.Value == null)
                {
                    return default;
                }
                if(prop.Value.GetType() == typeof(T))
                {
                    return (T)prop.Value;
                }
                TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));
                if (typeConverter.CanConvertFrom(prop.Value.GetType()))
                {
                    return (T)typeConverter.ConvertFrom(prop.Value);
                }
            }
            throw new Exception($"Property '{name}' not found.");
        }

        public string ToJson()
        {
            return ToJson(false);
        }

        public string ToJson(bool pretty = false)
        {
            return ToJson(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }, pretty);
        }

        public string ToJson(JsonSerializerSettings settings, bool pretty = false)
        {
            Dictionary<string, object> keyValuePairs = GetValueDictionary();

            return JsonConvert.SerializeObject(keyValuePairs, pretty ? Formatting.Indented : Formatting.None, settings);
        }

        /// <summary>
        /// Load the specified JSON string into the vocabulary object, setting properties accordingly.
        /// </summary>
        /// <param name="json"></param>
        /// <exception cref="InvalidCastException"></exception>
        public void LoadJson(string json)
        {
            Dictionary<string, object>? keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if(keyValuePairs == null)
            {
                throw new InvalidCastException("The provided JSON could not be deserialized into a Dictionary<string, object>.");
            }

            foreach(string propertyName in keyValuePairs.Keys)
            {
                Property(propertyName, keyValuePairs[propertyName]);
            }
        }

        private void AddProperty(IProperty property)
        {
            if (!_properties.ContainsKey(property.Name))
            {
                _properties.Add(property.Name, property);
            }
        }

        private Dictionary<string, object> GetValueDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            foreach (IProperty property in Properties)
            {
                if (property.Value != null)
                {
                    keyValuePairs.Add(property.Name, property.Value);
                }
            }

            return keyValuePairs;
        }
    }
}
