using SoftTouch.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Processors;

public class IterNameProcessor : Processor<Query<NameComponent>>
{
    public override void Update()
    {
        var iter = Entities1.GetEnumerator();
        while(iter.MoveNext())
        {
            iter.Current.Set(new NameComponent("Jolyne"));
        }
    }

}
