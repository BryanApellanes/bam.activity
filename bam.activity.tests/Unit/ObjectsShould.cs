using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.Test;

namespace Bam.Activity.Tests.Unit
{
    [UnitTestMenu("RuntimeConfig should")]
    public class ObjectsShould : UnitTestMenuContainer
    {
        [UnitTest]
        public void SerializeWithContextAndType()
        {
            Type[] types = typeof(VocabularyObjectRoot).Assembly.GetTypes().Where(t => t.ExtendsType(typeof(VocabularyObjectRoot))).ToArray();
            IdHost idHost = new IdHost("http://example.org/");

            When.A<IdHost>("serializes vocabulary objects with context and type",
                idHost,
                (host) =>
                {
                    int testedCount = 0;
                    foreach (Type type in types)
                    {
                        object instance = type.Construct(host);
                        VocabularyObjectRoot vocabObject = (VocabularyObjectRoot)instance;
                        string json = vocabObject.ToJson(true);
                        Dictionary<string, object> keyValuePairs = json.FromJson<Dictionary<string, object>>();
                        if (!keyValuePairs.ContainsKey("@context") || !keyValuePairs.ContainsKey("type"))
                        {
                            throw new Exception($"Type {type.Name} missing @context or type key");
                        }
                        testedCount++;
                    }
                    return testedCount;
                })
            .TheTest
            .ShouldPass(because =>
            {
                int testedCount = (int)because.Result;
                because.ItsTrue("tested at least one type", testedCount > 0);
                because.ItsTrue($"all {types.Length} types serialized with context and type", testedCount == types.Length);
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void DeserializeExamples()
        {
            string expected = @"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Video"",
  ""name"": ""Puppy Plays With Ball"",
  ""url"": ""http://example.org/video.mkv"",
  ""duration"": ""PT2H""
}".Replace("\r\n", "\n");

            When.A<Video>("deserializes example JSON correctly",
                () => new Video("http://example.org/"),
                (video) =>
                {
                    string actual = video.Examples.Last().Replace("\r\n", "\n");
                    video.LoadJson(actual);
                    return new object?[] { actual, video.Name, video.Url?.ToString(), video.Duration?.ToString(), video.ToJson(true).Replace("\r\n", "\n") };
                })
            .TheTest
            .ShouldPass(because =>
            {
                object?[] results = (object?[])because.Result;
                string actual = (string)results[0]!;
                string? name = (string?)results[1];
                string? url = (string?)results[2];
                string? duration = (string?)results[3];
                string? roundTrip = (string?)results[4];
                because.ItsTrue("example JSON matches expected", expected.Equals(actual));
                because.ItsTrue("Name is not null", name != null);
                because.ItsTrue("Name equals expected", "Puppy Plays With Ball".Equals(name));
                because.ItsTrue("Url equals expected", "http://example.org/video.mkv".Equals(url));
                because.ItsTrue("Duration equals expected", "PT2H".Equals(duration));
                because.ItsTrue("round-trip JSON matches expected", expected.Equals(roundTrip));
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void LoadExampleJson()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "JsonFiles"));

            When.A<DirectoryInfo>("loads and validates all example JSON files",
                directoryInfo,
                (dir) =>
                {
                    FileInfo[] files = dir.GetFiles("*.json");
                    int loadedCount = 0;
                    foreach (FileInfo fileInfo in files)
                    {
                        string json = File.ReadAllText(fileInfo.FullName);
                        Dictionary<string, object> keyValuePairs = json.FromJson<Dictionary<string, object>>();
                        string typeName = fileInfo.Name.Split('_', '.')[0];
                        Type type = typeof(VocabularyObjectRoot).Assembly.GetTypes().First(t => t.Name.Equals(typeName));
                        VocabularyObjectRoot instance = type.Construct<VocabularyObjectRoot>(new IdHost("http://example.org/"));
                        instance.LoadJson(json);
                        foreach (string propertyName in keyValuePairs.Keys)
                        {
                            object? property;
                            try
                            {
                                property = instance.Property(propertyName);
                            }
                            catch
                            {
                                continue;
                            }
                            if (property == null)
                            {
                                throw new Exception($"Property '{propertyName}' was null for type {typeName} in file {fileInfo.Name}");
                            }
                            if (keyValuePairs[propertyName] is string value && !property.ToString()!.Equals(value))
                            {
                                throw new Exception($"Property '{propertyName}' mismatch for {typeName}: expected '{value}' but got '{property}'");
                            }
                        }
                        loadedCount++;
                    }
                    return loadedCount;
                })
            .TheTest
            .ShouldPass(because =>
            {
                because.TheResult.IsNotNull();
                if (because.Result is int loadedCount)
                {
                    because.ItsTrue("loaded at least one JSON file", loadedCount > 0);
                }
            })
            .SoBeHappy()
            .UnlessItFailed();
        }
    }
}
