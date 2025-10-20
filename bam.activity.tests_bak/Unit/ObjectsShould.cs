using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.Test;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Tests.Unit
{
    [UnitTestMenu("RuntimeConfig should")]
    public class ObjectsShould : UnitTestMenuContainer
    {
        [UnitTest]
        public async Task SerializeWithContextAndType()
        {
            Type[] types = typeof(VocabularyObjectRoot).Assembly.GetTypes().Where(t => t.ExtendsType(typeof(VocabularyObjectRoot))).ToArray();
            IdHost idHost = new IdHost("http://example.org/");

            foreach (Type type in types)
            {
                object instance = type.Construct(idHost);
                instance.ShouldNotBeNull();
                IJsonable jsonable = instance as IJsonable;
                jsonable.ShouldNotBeNull();
                string json = jsonable.ToJson();
                Dictionary<string, object> keyValuePairs = json.FromJson<Dictionary<string, object>>();
                keyValuePairs.ContainsKey("@context").ShouldBeTrue();
                keyValuePairs.ContainsKey("type").ShouldBeTrue();
                Message.PrintLine(json);
            }
        }
    }
}
