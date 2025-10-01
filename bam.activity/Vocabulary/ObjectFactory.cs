using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public class ObjectFactory
    {
        public ObjectFactory(Uri defaultIdHost)
        {
            this.IdHost = new IdHost(defaultIdHost);
        }

        public IdHost IdHost { get; set; }
    }
}
