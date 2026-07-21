using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    public class IdFormatter : IIdFormatter
    {
        public IdFormatter(IdHost idHost)
        {
            this.IdHost = idHost;
        }

        public IdHost IdHost { get; set; }

        public string FormatId(string id)
        {
            if (Uri.IsWellFormedUriString(id, UriKind.Absolute))
            {
                return id;
            }
            return $"{IdHost.Host}/{id}";
        }

        public string FormatId(string type, string id)
        {
            return $"{IdHost.Host}/{type}/{id}";
        }
    }
}
