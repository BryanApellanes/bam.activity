using System;

namespace Bam.Activity.Vocabulary
{
    /// <summary>
    /// Represents an organization.
    /// </summary>
    public partial class Organization : Object, IOrganization
    {
        public Organization(IdHost idHost) : base(idHost)
        {
            this.StartCtorInit(idHost);

            this.Example(@"{
  ""@context"": ""https://www.w3.org/ns/activitystreams"",
  ""type"": ""Organization"",
  ""name"": ""Example Co.""
}");
            this.EndCtorInit(idHost);
        }


    }
}