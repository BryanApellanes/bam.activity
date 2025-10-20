using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public class IdHost
    {
        public static implicit operator string(IdHost idHost) => idHost.Host;
        public static implicit operator IdHost(string host) => new IdHost(host);
        public static implicit operator Uri(IdHost idHost) => new Uri(idHost.Host);
        public static implicit operator IdHost(Uri uri) => new IdHost(uri.ToString());

        static IdHost()
        {
            Default = new IdHost("https://example.com");
        }

        public IdHost(string uri)
            : this(new Uri(uri))
        {
        }

        public IdHost(Uri uri)
        {
            this.Host = $"{uri.Scheme}://{uri.Host}";
        }

        public string Host { get; }

        public static IdHost Default
        {
            get;
            set;
        }
    }
}
