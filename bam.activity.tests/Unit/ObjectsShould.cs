using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.Test;
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
                VocabularyObjectRoot vocabObject = instance as VocabularyObjectRoot;
                vocabObject.ShouldNotBeNull();
                string json = vocabObject.ToJson(true);
                Dictionary<string, object> keyValuePairs = json.FromJson<Dictionary<string, object>>();
                keyValuePairs.ContainsKey("@context").ShouldBeTrue();
                keyValuePairs.ContainsKey("type").ShouldBeTrue();
                Message.PrintLine(json);
            }
        }

        [UnitTest]
        public async Task DeserializeExamples()
        {
            string expected = @"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Video"",
  ""name"": ""Puppy Plays With Ball"",
  ""url"": ""http://example.org/video.mkv"",
  ""duration"": ""PT2H""
}";

            Video video = new Video("http://example.org/");
            string actual = video.Example().Replace("\n", "\r\n");

            actual.ShouldEqual(expected);

            video.LoadJson(actual);

            video.Name.ShouldNotBeNull();
            video.Name.ShouldBeEqualTo("Puppy Plays With Ball");
            video.Url.ToString().ShouldEqual("http://example.org/video.mkv");
            video.Duration.ToString().ShouldEqual("PT2H");
            TimeSpan timeSpan = (TimeSpan)video.Duration;
            timeSpan.Hours.ShouldBeEqualTo(2);
            video.ToJson(true).ShouldEqual(expected);
        }

        [UnitTest]
        public async Task LoadExampleJson()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "JsonFiles"));
            foreach(FileInfo fileInfo in directoryInfo.GetFiles("*.json"))
            {
                string json = await File.ReadAllTextAsync(fileInfo.FullName);
                Dictionary<string, object> keyValuePairs = json.FromJson<Dictionary<string, object>>();
                string typeName = fileInfo.Name.Split('_', '.')[0];
                Type type = typeof(VocabularyObjectRoot).Assembly.GetTypes().First(t => t.Name.Equals(typeName));
                if(type == null)
                {
                    throw new Exception($"Type '{typeName}' not found.");
                }
                VocabularyObjectRoot instance = type.Construct<VocabularyObjectRoot>(new IdHost("http://example.org/"));
                instance.GetType().ShouldEqual(type);
                instance.LoadJson(json);
                foreach(string propertyName in keyValuePairs.Keys)
                {
                    object? property = instance.Property(propertyName);
                    property?.ShouldNotBeNull();
                    object value = keyValuePairs[propertyName];
                    property.ToString().ShouldEqual(value.ToString());
                }
            }
        }
    }
}
