using Bam.Activity.Vocabulary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Activity.Vocabulary
{
    public partial class OrderedCollectionPage : Object, IOrderedCollection, ICollectionPage, IOrderedCollectionPage
    {
        protected override void StartCtorInit(params object[] args)
        {
            this.InitProperty("orderedItems", new List<object>(), false);
            base.StartCtorInit(args);
        }
    }
}
