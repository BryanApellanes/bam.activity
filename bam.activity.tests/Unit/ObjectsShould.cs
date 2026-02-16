using Bam.Activity.Vocabulary;
using Bam.Console;
using Bam.Data.Repositories;
using Bam.Test;
using Newtonsoft.Json.Linq;
using Object = Bam.Activity.Vocabulary.Object;

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

        [UnitTest]
        public void FormatIds()
        {
            IdHost idHost = new IdHost("http://example.org/");
            IdFormatter formatter = new IdFormatter(idHost);

            When.A<IdFormatter>("formats IDs correctly",
                formatter,
                (fmt) =>
                {
                    string bare = fmt.FormatId("12345");
                    string absolute = fmt.FormatId("http://other.org/thing/1");
                    string typed = fmt.FormatId("Note", "42");
                    return new string[] { bare, absolute, typed };
                })
            .TheTest
            .ShouldPass(because =>
            {
                string[] results = (string[])because.Result;
                because.ItsTrue("bare ID is prefixed with host", "http://example.org/12345".Equals(results[0]));
                because.ItsTrue("absolute URI passes through unchanged", "http://other.org/thing/1".Equals(results[1]));
                because.ItsTrue("typed ID includes type segment", "http://example.org/Note/42".Equals(results[2]));
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void CreateObjectsFromFactory()
        {
            IdHost idHost = new IdHost("http://example.org/");
            ObjectFactory factory = new ObjectFactory(idHost);

            When.A<ObjectFactory>("creates vocabulary objects via factory",
                factory,
                (f) =>
                {
                    Note note = f.Create<Note>("my-note");
                    VocabularyObjectRoot noteByName = f.Create("Note", "note-2");
                    bool invalidResult = f.TryCreate("InvalidTypeName", out VocabularyObjectRoot invalid);
                    return new object[] { note, noteByName, invalidResult, invalid };
                })
            .TheTest
            .ShouldPass(because =>
            {
                object[] results = (object[])because.Result;
                Note note = (Note)results[0];
                VocabularyObjectRoot noteByName = (VocabularyObjectRoot)results[1];
                bool invalidResult = (bool)results[2];
                object invalid = results[3];

                because.ItsTrue("Create<Note> returns a Note", note != null);
                because.ItsTrue("Create<Note> id is formatted", "http://example.org/Note/my-note".Equals(note.Property("id")));
                because.ItsTrue("Create by name returns a Note", noteByName is Note);
                because.ItsTrue("Create by name id is formatted", "http://example.org/Note/note-2".Equals(noteByName.Property("id")));
                because.ItsTrue("TryCreate with invalid name returns false", !invalidResult);
                because.ItsTrue("TryCreate with invalid name outputs null", invalid == null);
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void MatchRangeValues()
        {
            When.A<IdHost>("dispatches Range values correctly",
                new IdHost("http://example.org/"),
                (idHost) =>
                {
                    Range<string, int> rangeStr = Range<string, int>.Of("hello");
                    Range<string, int> rangeInt = Range<string, int>.Of(42);

                    string matchStr = rangeStr.Match(s => $"string:{s}", i => $"int:{i}");
                    string matchInt = rangeInt.Match(s => $"string:{s}", i => $"int:{i}");

                    return new object[]
                    {
                        rangeStr.HasValue, rangeStr.HasValue2,
                        rangeInt.HasValue, rangeInt.HasValue2,
                        rangeStr.GetActiveValue(), rangeStr.GetActiveType(),
                        rangeInt.GetActiveValue(), rangeInt.GetActiveType(),
                        matchStr, matchInt
                    };
                })
            .TheTest
            .ShouldPass(because =>
            {
                object[] r = (object[])because.Result;
                because.ItsTrue("string range HasValue is true", (bool)r[0]);
                because.ItsTrue("string range HasValue2 is false", !(bool)r[1]);
                because.ItsTrue("int range HasValue is false", !(bool)r[2]);
                because.ItsTrue("int range HasValue2 is true", (bool)r[3]);
                because.ItsTrue("string range active value is 'hello'", "hello".Equals(r[4]));
                because.ItsTrue("string range active type is string", typeof(string).Equals(r[5]));
                because.ItsTrue("int range active value is 42", 42.Equals(r[6]));
                because.ItsTrue("int range active type is int", typeof(int).Equals(r[7]));
                because.ItsTrue("Match dispatches to string handler", "string:hello".Equals(r[8]));
                because.ItsTrue("Match dispatches to int handler", "int:42".Equals(r[9]));
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void SerializeNestedObjects()
        {
            IdHost idHost = new IdHost("http://example.org/");

            When.A<IdHost>("serializes and deserializes nested objects",
                idHost,
                (host) =>
                {
                    Create create = new Create(host);
                    create.Summary = "Sally created a note";
                    Person actor = new Person(host);
                    actor.Name = "Sally";
                    create.Property("actor", actor);

                    Note note = new Note(host);
                    note.Name = "A Simple Note";
                    note.Content = "This is a simple note";
                    create.Property("object", note);

                    string json = create.ToJson(true);

                    // Verify nested objects appear as JSON objects, not raw references
                    JObject parsed = JObject.Parse(json);
                    bool actorIsObject = parsed["actor"] is JObject;
                    bool objectIsObject = parsed["object"] is JObject;
                    string actorType = parsed["actor"]?["type"]?.ToString();
                    string objectType = parsed["object"]?["type"]?.ToString();

                    // Round-trip: load JSON into a new Create
                    Create loaded = new Create(host);
                    loaded.LoadJson(json);
                    object loadedActor = loaded.Property("actor");
                    object loadedObject = loaded.Property("object");

                    return new object[]
                    {
                        actorIsObject, objectIsObject,
                        actorType, objectType,
                        loadedActor is VocabularyObjectRoot,
                        loadedObject is VocabularyObjectRoot,
                        json
                    };
                })
            .TheTest
            .ShouldPass(because =>
            {
                object[] r = (object[])because.Result;
                because.ItsTrue("actor serialized as JSON object", (bool)r[0]);
                because.ItsTrue("object serialized as JSON object", (bool)r[1]);
                because.ItsTrue("actor type is Person", "Person".Equals(r[2]));
                because.ItsTrue("object type is Note", "Note".Equals(r[3]));
                because.ItsTrue("loaded actor is VocabularyObjectRoot", (bool)r[4]);
                because.ItsTrue("loaded object is VocabularyObjectRoot", (bool)r[5]);
            })
            .SoBeHappy()
            .UnlessItFailed();
        }
    }
}
