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
        var entities = Entities1.CreateIterator();
        while(entities.Next())
        {
            entities.Set(new NameComponent("Jolyne"));
        }
    }

}
