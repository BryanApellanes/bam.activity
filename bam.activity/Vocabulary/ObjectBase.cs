using System;
using System.Collections.Generic;
using System.Text;
using bam.Activity.Vocabulary;
using Bam;

namespace Bam.Activity.Vocabulary
{
    public abstract class ObjectBase : IObject
    {
        List<IProperty> _properties = new List<IProperty>();
        IdHost _idHost;

        public ObjectBase(IdHost idHost)
        {
            _properties.Add(new Property("@context", ActivityStreams.Context, true));
            _properties.Add(new Property("type", this.GetType().Name, true));
        }

        public IEnumerable<IProperty> Properties
        {
            get => _properties;
        }

        public void Property(string name, object? value, bool isFunctional = false)
        {
            IProperty? property = _properties.Find(p => p.Name == name);
            if(property == null)
            {
                property = new Property(name, value, isFunctional);
                _properties.Add(property);
            }
            else
            {
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

        public object? Property(string name)
        {
            IProperty? property = _properties.Find(p => p.Name == name);
            if (property == null)
            {
                throw new Exception($"Property '{name}' not found.");
            }
            return property.Value;
        }

        public string ToJson()
        {
            return _properties.ToJson();
        }
    }
}
