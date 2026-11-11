using Bag;
using Bag.Commands;
using Bam.Test;

namespace Bam.Activity.Tests.Unit
{
    /// <summary>
    /// Pins how bag reads the ActivityStreams vocabulary tables (bam.activity#2): the HTML parser moved from
    /// CsQuery to CsQuery.Core, and these cases cover every selector the generator relies on.
    /// </summary>
    [UnitTestMenu("Vocabulary parsing should")]
    public class VocabularyParsingShould : UnitTestMenuContainer
    {
        private const string TypesHtml = @"<html><body>
<section id=""types""><table>
<tbody>
  <tr><td rowspan=""5""><dfn>Relationship</dfn></td><td>URI:</td><td><code>https://www.w3.org/ns/activitystreams#Relationship</code></td></tr>
  <tr><td>Notes:</td><td>Describes a relationship between two individuals.</td></tr>
  <tr><td>Extends:</td><td><a href=""#dfn-object"">Object</a></td></tr>
  <tr><td>Properties:</td><td><p><a href=""#dfn-subject"">subject</a> | <a href=""#dfn-object-term"">object</a> | <a href=""#dfn-subject"">Subject</a></p><p>Inherits all properties from <a href=""#dfn-object"">Object</a>.</p></td></tr>
  <tr><td colspan=""2"">Example 1<pre>{ ""type"": ""Relationship"" }</pre></td></tr>
</tbody>
<tbody>
  <tr><td rowspan=""3""><dfn>Link</dfn></td><td>URI:</td><td><code>https://www.w3.org/ns/activitystreams#Link</code></td></tr>
  <tr><td>Notes:</td><td>A Link is an indirect, qualified reference to a resource.</td></tr>
  <tr><td>Properties:</td><td>Inherits all properties from <a href=""#dfn-object"">Object</a>.</td></tr>
</tbody>
</table></section>
<section id=""object-types""><table>
<tbody>
  <tr><td><dfn>Note</dfn></td><td>URI:</td><td><code>https://www.w3.org/ns/activitystreams#Note</code></td></tr>
</tbody>
</table></section>
</body></html>";

        private const string PropertiesHtml = @"<html><body>
<section id=""properties""><table>
<tbody>
  <tr><td rowspan=""5""><dfn>actor</dfn></td><td>URI:</td><td><code>https://www.w3.org/ns/activitystreams#actor</code></td></tr>
  <tr><td>Notes:</td><td>Describes one or more entities that performed the activity.</td></tr>
  <tr><td>Domain:</td><td><a href=""#dfn-activity"">Activity</a></td></tr>
  <tr><td>Range:</td><td><a href=""#dfn-object"">Object</a> | <a href=""#dfn-link"">Link</a></td></tr>
</tbody>
<tbody>
  <tr><td rowspan=""4""><dfn>accuracy</dfn></td><td>URI:</td><td><code>https://www.w3.org/ns/activitystreams#accuracy</code></td></tr>
  <tr><td>Domain:</td><td><a href=""#dfn-place"">Place</a></td></tr>
  <tr><td>Range:</td><td><code>xsd:float</code></td></tr>
  <tr><td>Functional:</td><td>True</td></tr>
</tbody>
</table></section>
</body></html>";

        [UnitTest]
        public void ReadTypeDefinitionsFromTheSelectedTable()
        {
            When.A<string>("parses the type tables of a vocabulary page",
                TypesHtml,
                (html) => new TypesOutcome(
                    Generate.ParseTypeDefinitions(html, "#types > table"),
                    Generate.ParseTypeDefinitions(html, "#object-types > table"),
                    Generate.ParseTypeDefinitions(html, "#actor-types > table")))
            .TheTest
            .ShouldPass<TypesOutcome>((because, _, outcome) =>
            {
                because.ItsTrue("one definition per tbody", outcome.CoreTypes.Count == 2);
                VocabularyTypeDefinition relationship = outcome.CoreTypes[0];
                because.ItsTrue("Relationship is renamed RelationshipDescriptor", "RelationshipDescriptor".Equals(relationship.Name));
                because.ItsTrue("the uri is read", "https://www.w3.org/ns/activitystreams#Relationship".Equals(relationship.Uri));
                because.ItsTrue("the notes are read", "Describes a relationship between two individuals.".Equals(relationship.Notes));
                because.ItsTrue("the extended type is read", "Object".Equals(relationship.Extends));
                because.ItsTrue("properties come from the first paragraph only, without case-insensitive duplicates",
                    relationship.Properties.SetEquals(new string[] { "subject", "object" }));
                because.ItsTrue("the example is read", relationship.Examples.Count == 1 && relationship.Examples[0].Contains("\"Relationship\""));

                VocabularyTypeDefinition link = outcome.CoreTypes[1];
                because.ItsTrue("the second definition is Link", "Link".Equals(link.Name));
                because.ItsTrue("inherited-only properties are not listed", link.Properties.Count == 0);
                because.ItsTrue("a type with no Extends row has none", link.Extends == null);

                because.ItsTrue("the selector picks the table", outcome.ObjectTypes.Count == 1 && "Note".Equals(outcome.ObjectTypes[0].Name));
                because.ItsTrue("a selector that matches nothing yields nothing", outcome.ActorTypes.Count == 0);
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void ReadPropertyDefinitions()
        {
            When.A<string>("parses the properties table of a vocabulary page",
                PropertiesHtml,
                (html) => Generate.ParsePropertyDefinitions(html))
            .TheTest
            .ShouldPass<List<VocabularyPropertyDefinition>>((because, _, definitions) =>
            {
                because.ItsTrue("one definition per tbody", definitions.Count == 2);
                VocabularyPropertyDefinition actor = definitions[0];
                because.ItsTrue("the name is read", "actor".Equals(actor.Name));
                because.ItsTrue("the uri is read", "https://www.w3.org/ns/activitystreams#actor".Equals(actor.Uri));
                because.ItsTrue("the domain is read", "Activity".Equals(actor.Domain));
                because.ItsTrue("a linked range is read", actor.Range.SequenceEqual(new string[] { "Object", "Link" }));
                because.ItsTrue("a property with no Functional row is not functional", !actor.IsFunctional);

                VocabularyPropertyDefinition accuracy = definitions[1];
                because.ItsTrue("a code range is read", accuracy.Range.SequenceEqual(new string[] { "xsd:float" }));
                because.ItsTrue("the functional flag is read", accuracy.IsFunctional);
                because.ItsTrue("a property with no Notes row has none", accuracy.Notes == null);
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        [UnitTest]
        public void KeepThePropertyTypeMapOnThePropertyModel()
        {
            When.A<VocabularyPropertyDefinition>("builds a PropertyModel",
                new VocabularyPropertyDefinition { Name = "actor", Range = new List<string> { "Object", "Link" } },
                (definition) => new PropertyModel(definition, new Dictionary<string, string> { { "Object", "IObject" }, { "Link", "ILink" } }))
            .TheTest
            .ShouldPass<PropertyModel>((because, _, model) =>
            {
                because.ItsTrue("the map passed to the constructor is kept", model.PropertyTypeMap != null && model.PropertyTypeMap.Count == 2);
                because.ItsTrue("the return type covers every mapped range", "Range<IObject, ILink>".Equals(model.ReturnType));
                because.ItsTrue("missing notes render empty", string.Empty.Equals(model.Notes));
            })
            .SoBeHappy()
            .UnlessItFailed();
        }

        private sealed record TypesOutcome(
            List<VocabularyTypeDefinition> CoreTypes,
            List<VocabularyTypeDefinition> ObjectTypes,
            List<VocabularyTypeDefinition> ActorTypes);
    }
}
