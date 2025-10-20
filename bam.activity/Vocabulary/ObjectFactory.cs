using Bam.Activity.Vocabulary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Activity.Vocabulary
{
    public class ObjectFactory
    {
        public ObjectFactory(Uri defaultIdHost, IIdFormatter idformatter)
        {
            this.IdHost = new IdHost(defaultIdHost);
            this.IdFormatter = idformatter;
        }

        public IdHost IdHost { get; set; }
        public IIdFormatter IdFormatter { get; set; }


    }
}
