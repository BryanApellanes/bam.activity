# bam.activity

A .NET library implementing the W3C ActivityStreams 2.0 vocabulary as strongly-typed C# classes.

## Overview

bam.activity provides a complete C# object model for the [W3C Activity Streams 2.0](https://www.w3.org/TR/activitystreams-vocabulary/) specification. It includes generated classes and interfaces for all core types (Object, Activity, Collection), activity types (Create, Delete, Follow, Like, etc.), actor types (Person, Organization, Application, Service, Group), and object types (Article, Audio, Document, Event, Image, Note, Page, Video, etc.).

Each vocabulary type is represented as a partial class extending `VocabularyObjectRoot`, with properties modeled using a generic `Range<T1, T2>` type that mirrors the multi-valued range concept from the ActivityStreams specification. Properties are initialized in constructors with metadata about their range types and functional status, and each type includes embedded JSON examples from the W3C specification.

The library supports JSON serialization and deserialization of ActivityStreams documents, with each object carrying an `@context` of `https://www.w3.org/ns/activitystreams` and a `type` field. The property system uses `IProperty` for dynamic property access with support for JSON output.

## Key Classes

| Class | Description |
|---|---|
| `Object` | Base type for all ActivityStreams objects; defines properties like name, content, attachment, audience, published, etc. |
| `Activity` | Represents an action with actor, object, target, result, origin, and instrument properties |
| `Collection` | An ordered or unordered set of Objects |
| `CollectionPage` | A page within a Collection |
| `Link` | A qualified reference to another resource |
| `Person` | Represents an individual person |
| `Note` | A short text entry, analogous to a social media post |
| `Create` / `Delete` / `Update` | Activity subtypes for CRUD operations |
| `Follow` / `Like` / `Block` | Social interaction activity types |
| `Range<T1>` / `Range<T1, T2>` | Generic wrapper modeling the multi-type range concept from the spec, with implicit conversion operators |
| `IProperty` | Interface for dynamic property access with name, value, range, and JSON serialization |
| `ActivityStreams` | Constants class holding the ActivityStreams context URL |
| `MediaType` | Constants for ActivityStreams media types (`application/activity+json`) |
| `IdFormatter` | Formats IDs for vocabulary objects (stub implementation) |
| `VocabularyObjectRoot` | Abstract base class for all vocabulary types providing property management and JSON serialization |

## Dependencies

**Project References:**
- `bam.base` -- Core BAM framework library

**Target Framework:** net10.0

## Usage Examples

```csharp
using Bam.Activity.Vocabulary;

// Create a new Note
var idHost = new IdHost("http://example.org/");
var note = new Note(idHost);
note.Name = "My First Note";
note.Content = "This is the content of my note.";
note.Published = DateTime.UtcNow;

// Serialize to JSON
string json = note.ToJson(true);
// Produces:
// {
//   "@context": "https://www.w3.org/ns/activitystreams",
//   "type": "Note",
//   "name": "My First Note",
//   "content": "This is the content of my note.",
//   "published": "2025-01-01T00:00:00Z"
// }

// Create an Activity
var create = new Create(idHost);
create.Actor = new Range<Object, Link> { Value = new Person(idHost) { Name = "Sally" } };
create.Object = new Range<Object, Link> { Value = note };

// Deserialize from JSON
var video = new Video("http://example.org/");
video.LoadJson(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Video"",
  ""name"": ""Puppy Plays With Ball"",
  ""url"": ""http://example.org/video.mkv"",
  ""duration"": ""PT2H""
}");
```

## Known Gaps / Not Yet Implemented

- **`IdFormatter.FormatId()`** throws `NotImplementedException` -- the ID formatting logic for vocabulary objects is not yet implemented.
- The `Range<T1, T2>` type uses implicit conversion operators but does not implement full union-type semantics; only `Value` and `Value2` are accessible.
- No built-in support for JSON-LD processing beyond the `@context` and `type` fields.
