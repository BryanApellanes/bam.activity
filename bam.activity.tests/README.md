# bam.activity.tests

Unit and integration tests for the bam.activity ActivityStreams vocabulary library.

## Overview

bam.activity.tests is a console-based test runner that validates the bam.activity library's implementation of the W3C ActivityStreams 2.0 vocabulary. It uses the BAM test framework (`BamConsoleContext.StaticMain` with `[UnitTestMenu]` and `When.A<T>()` fluent API) rather than xUnit or NUnit.

The test project includes a comprehensive set of JSON fixture files (over 100 files in the `JsonFiles/` directory) representing examples of every ActivityStreams type -- from Accept and Activity through Video and View. These fixtures are used to validate that vocabulary types can correctly load, parse, and round-trip JSON representations.

The project also includes command-line analysis tools for inspecting the generated vocabulary types, such as listing property ranges and enumerating all `VocabularyObjectRoot` subtypes.

## Key Classes

| Class | Description |
|---|---|
| `ObjectsShould` | Core unit test class with tests for serialization, deserialization, and JSON example loading |
| `Analyze` | Console menu for inspecting generated vocabulary types: property ranges and type listing |
| `Program` | Entry point using `BamConsoleContext.StaticMain` |

## Test Methods

| Test | Description |
|---|---|
| `SerializeWithContextAndType` | Verifies all VocabularyObjectRoot subtypes serialize with `@context` and `type` JSON keys |
| `DeserializeExamples` | Round-trip test: deserializes a Video example, validates properties, re-serializes and compares |
| `LoadExampleJson` | Loads all JSON fixture files from `JsonFiles/`, instantiates the corresponding type, and validates properties |

## Dependencies

**Project References:**
- `bam.tests` -- BAM test framework
- `bam.base` -- Core BAM framework
- `bam.console` -- Console menu infrastructure
- `bam.activity` -- The library under test

**Target Framework:** net10.0
**Output Type:** Exe

## Usage Examples

```bash
# Run all unit tests
dotnet run --project bam.activity.tests -- --ut

# Run interactively to access the menu
dotnet run --project bam.activity.tests
```

## Known Gaps / Not Yet Implemented

- No tests for the `IdFormatter` class (which has a `NotImplementedException` in bam.activity).
- Tests do not validate nested object deserialization (e.g., an Activity with a fully populated Actor sub-object).
- The `LoadExampleJson` test silently skips properties that throw exceptions during access (via a `catch` with `continue`).
