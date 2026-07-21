# bag (Bam Activity Generator)

A command-line code generator that produces C# classes and interfaces from the W3C ActivityStreams vocabulary specification.

## Overview

bag is a console application that scrapes the W3C ActivityStreams vocabulary HTML specification, parses type and property definitions, and generates strongly-typed C# code using Handlebars templates. It automates the creation of the vocabulary classes found in the `bam.activity` library.

The tool works in two phases. First, it downloads and parses HTML from the W3C spec using CsQuery (a CSS selector engine for .NET), extracting type definitions (name, URI, extends, properties, examples) and property definitions (name, URI, domain, range, functional status) into YAML files. Second, it reads those YAML definitions, resolves type hierarchies and property ranges, and generates C# class and interface files using embedded Handlebars templates (`Object.hbs`, `Interface.hbs`, `ClassProperty.hbs`, etc.).

The generator supports configurable output directories, target namespaces, and a property type map (`.kvp` file) that controls how ActivityStreams range types are mapped to C# types.

## Key Classes

| Class | Description |
|---|---|
| `VocabularyCodeGenerator` | Main generator: reads YAML definitions, applies Handlebars templates, writes .cs files |
| `VocabularyLookup` | Loads and indexes type and property definitions from YAML files |
| `VocabularyModel` | Template model for a single vocabulary type: class name, interface list, properties, examples |
| `VocabularyTypeDefinition` | Data class for a vocabulary type: name, URI, extends, properties, notes, examples |
| `VocabularyPropertyDefinition` | Data class for a vocabulary property: name, URI, domain, range, functional flag |
| `PropertyModel` | Template model for a single property within a type |
| `PropertyTypeMap` | Loads the range-to-C#-type mapping from a `.kvp` file |
| `BamVocabularyGeneratorConfig` | Configuration for directories, namespace, and paths |
| `Generate` (command) | Console menu with commands: download types/properties, generate code, init config |
| `Analyze` (command) | Console menu with commands: show extends, show ranges, init property type map |
| `Configurer` | Configures the service registry for the generator |
| `IInput` / `FileInput` / `PromptInput` | Input abstraction for URL/file path parameters |

## Dependencies

**Project References:**
- `bam.console` -- Console menu infrastructure and `BamConsoleContext`
- `bam.generators` -- Handlebars template rendering (`ITemplateRenderer`, `HandlebarsEmbeddedResources`)

**Package References:**
- `CsQuery` 1.3.4 -- CSS selector-based HTML parsing

**Target Framework:** net10.0
**Output Type:** Exe

## Usage Examples

```bash
# Initialize generator configuration
dotnet run --project bag -- initConfig

# Download all type and property definitions from the W3C spec
dotnet run --project bag -- "Download all"

# Generate C# code from YAML definitions
dotnet run --project bag -- "Generate vocabulary code"

# Run interactively
dotnet run --project bag
```

## Known Gaps / Not Yet Implemented

- No automated tests for the generator itself.
- The `DownloadAll` method calls `Task.WaitAll` on async methods, which can deadlock in certain synchronization contexts.
- Property type map initialization (`InitPropertyTypeMapFromYamlDefinitions`) defaults all types to `string`, requiring manual editing.
- No incremental generation -- regenerating always overwrites all files.
