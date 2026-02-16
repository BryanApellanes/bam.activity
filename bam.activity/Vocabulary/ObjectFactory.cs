using Bam.Activity.Vocabulary;
using Bam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public class ObjectFactory
    {
        private static readonly Lazy<Dictionary<string, Type>> _typeRegistry = new Lazy<Dictionary<string, Type>>(() =>
        {
            Dictionary<string, Type> registry = new Dictionary<string, Type>();
            Type[] types = typeof(VocabularyObjectRoot).Assembly.GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsAbstract && !type.IsInterface && typeof(VocabularyObjectRoot).IsAssignableFrom(type))
                {
                    registry[type.Name] = type;
                }
            }
            return registry;
        });

        public ObjectFactory(Uri defaultIdHost, IIdFormatter idformatter)
        {
            this.IdHost = new IdHost(defaultIdHost);
            this.IdFormatter = idformatter;
        }

        public ObjectFactory(IdHost idHost)
        {
            this.IdHost = idHost;
            this.IdFormatter = new IdFormatter(idHost);
        }

        public IdHost IdHost { get; set; }
        public IIdFormatter IdFormatter { get; set; }

        public T Create<T>(string id = null) where T : VocabularyObjectRoot
        {
            T instance = typeof(T).Construct<T>(IdHost);
            if (id != null)
            {
                instance.Property("id", IdFormatter.FormatId(typeof(T).Name, id));
            }
            return instance;
        }

        public VocabularyObjectRoot Create(string typeName, string id = null)
        {
            Type type = ResolveType(typeName);
            if (type == null)
            {
                throw new ArgumentException($"Unknown vocabulary type: '{typeName}'");
            }
            return Create(type, id);
        }

        public VocabularyObjectRoot Create(Type type, string id = null)
        {
            VocabularyObjectRoot instance = type.Construct<VocabularyObjectRoot>(IdHost);
            if (id != null)
            {
                instance.Property("id", IdFormatter.FormatId(type.Name, id));
            }
            return instance;
        }

        public bool TryCreate(string typeName, out VocabularyObjectRoot result)
        {
            Type type = ResolveType(typeName);
            if (type == null)
            {
                result = null;
                return false;
            }
            result = Create(type);
            return true;
        }

        public static Type ResolveType(string typeName)
        {
            if (_typeRegistry.Value.TryGetValue(typeName, out Type type))
            {
                return type;
            }
            return null;
        }
    }
}
