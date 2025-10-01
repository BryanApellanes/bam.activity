using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public class IdHost
    {
        public static implicit operator string(IdHost idHost) => idHost.Host;

        public IdHost(string uri)
            : this(new Uri(uri))
        {
        }

        public IdHost(Uri uri)
        {
            this.Host = $"{uri.Scheme}://{uri.Host}";
        }

        public string Host { get; }
    }
}
