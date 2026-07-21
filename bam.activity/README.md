# bam.activity

A .NET library implementing the W3C ActivityStreams 2.0 vocabulary as strongly-typed C# classes.

## Overview

`bam.activity` provides a complete C# object model for the [W3C Activity Streams 2.0](https://www.w3.org/TR/activitystreams-vocabulary/) specification. It includes generated classes and interfaces for all core types (Object, Activity, Collection), activity types (Create, Delete, Follow, Like, etc.), actor types (Person, Organization, Application, Service, Group), and object types (Article, Audio, Document, Event, Image, Note, Page, Video, etc.).

Each vocabulary type is represented as a partial class extending `VocabularyObjectRoot`, with properties modeled using a generic `Range<T1, T2>` type that mirrors the multi-valued range concept from the ActivityStreams specification. Properties are initialized in constructors with metadata about their range types and functional status, and each type includes embedded JSON examples from the W3C specification.

The library supports JSON serialization and deserialization of ActivityStreams documents, with each object carrying an `@context` of `https://www.w3.org/ns/activitystreams` and a `type` field. The property system uses `IProperty` for dynamic property access with support for JSON output. Type converters (`DurationTypeConverter`, `LinkTypeConverter`) enable automatic conversion from strings to `Duration` and `Link` types respectively.

The `Generated/Code/` folder contains 54 generated vocabulary classes and 58 generated interfaces covering the full ActivityStreams vocabulary.

## Key Classes

| Class / Interface | Description |
|---|---|
| `VocabularyObjectRoot` | Abstract base class for all vocabulary types; manages a dictionary of `IProperty` instances, provides `ToJson()`/`LoadJson()` serialization, constructor hooks (`StartCtorInit`/`EndCtorInit`), and `InitProperty()` for property registration with range metadata. |
| `IVocabularyObjectRoot` | Interface for vocabulary objects: property access by name, typed property retrieval, and `IJsonable` support. |
| `Object` | Base type for all ActivityStreams objects; defines 24 properties including name, content, attachment, audience, published, duration, to/cc/bcc, etc. |
| `Activity` | Represents an action with actor, object, target, result, origin, and instrument properties. |
| `IntransitiveActivity` | An activity without a direct object. |
| `Collection` / `OrderedCollection` | Ordered or unordered sets of Objects with totalItems, current, first, last, and items properties. |
| `CollectionPage` / `OrderedCollectionPage` | A page within a Collection with partOf, next, and prev navigation. |
| `Link` | A qualified reference to another resource with href, rel, mediaType, name, and hreflang. |
| `Person` / `Organization` / `Group` | Actor types representing individuals, organizations, and groups. |
| `Application` / `Service` | Actor types for software applications and services. |
| `Note` | A short text entry, analogous to a social media post. |
| `Article` / `Document` / `Page` | Content object types. |
| `Audio` / `Image` / `Video` | Media object types. |
| `Event` / `Place` / `Profile` | Contextual object types. |
| `Create` / `Delete` / `Update` | CRUD activity subtypes. |
| `Accept` / `Reject` / `TentativeAccept` / `TentativeReject` | Response activity types. |
| `Follow` / `Like` / `Dislike` / `Block` / `Ignore` / `Flag` | Social interaction activity types. |
| `Add` / `Remove` / `Move` | Collection management activity types. |
| `Announce` / `Offer` / `Invite` / `Join` / `Leave` | Group and sharing activity types. |
| `Arrive` / `Travel` | Location activity types. |
| `Listen` / `Read` / `View` | Consumption activity types. |
| `Undo` | Reversal activity type. |
| `Question` | An activity representing a question with oneOf/anyOf/closed properties. |
| `Tombstone` | Represents a deleted object with formerType and deleted timestamp. |
| `Mention` | A specialized Link that represents an @mention. |
| `RelationshipDescriptor` | Describes a relationship between two objects with subject, object, and relationship properties. |
| `Range<T1>` / `Range<T1, T2>` | Generic wrapper modeling the multi-type range concept from the spec, with implicit conversion operators. |
| `IProperty` | Interface for dynamic property access with name, value, functional flag, range metadata, and JSON serialization. |
| `Property` | Concrete `IProperty` implementation with support for functional (single-value) and non-functional (list-value) properties. |
| `ActivityStreams` | Constants class holding the ActivityStreams context URL (`https://www.w3.org/ns/activitystreams`). |
| `MediaType` | Constants for ActivityStreams media types (`application/activity+json`). |
| `IdHost` | Wraps a host URI for vocabulary object ID generation; provides implicit conversions to/from `string` and `Uri`. |
| `IdFormatter` | Formats IDs for vocabulary objects (stub implementation). |
| `IIdFormatter` | Interface for ID formatting: `FormatId(string id)`. |
| `ObjectFactory` | Factory for creating vocabulary objects with a default `IdHost` and `IIdFormatter`. |
| `Duration` | Converts between ISO 8601 duration strings and .NET `TimeSpan` via `XmlConvert`. |
| `DurationTypeConverter` | `TypeConverter` for string-to-`Duration` conversion. |
| `LinkTypeConverter` | `TypeConverter` for string-to-`Link` conversion. |

## Dependencies

### Project References
- `bam.base` -- Core BAM framework library

### Package References
None.

**Target Framework:** net10.0

## Usage Examples

### Creating and serializing vocabulary objects
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
```

### Creating activities with actors and objects
```csharp
using Bam.Activity.Vocabulary;

var idHost = new IdHost("http://example.org/");

var create = new Create(idHost);
create.Actor = new Range<Object, Link> { Value = new Person(idHost) { Name = "Sally" } };
create.Object = new Range<Object, Link> { Value = new Note(idHost) { Name = "A Note" } };

string json = create.ToJson(true);
```

### Loading from JSON
```csharp
using Bam.Activity.Vocabulary;

var video = new Video("http://example.org/");
video.LoadJson(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Video"",
  ""name"": ""Puppy Plays With Ball"",
  ""url"": ""http://example.org/video.mkv"",
  ""duration"": ""PT2H""
}");
```

### Working with Duration
```csharp
using Bam.Activity.Vocabulary;

var duration = new Duration(TimeSpan.FromHours(2));
string iso8601 = duration.Value; // "PT2H"

TimeSpan timeSpan = (TimeSpan)new Duration("PT5M30S"); // 5 minutes 30 seconds
```

## Known Gaps / Not Yet Implemented

None currently tracked.
