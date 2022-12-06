using SoftTouch.ECS;
using SoftTouch.ECS.Arrays;
using System.Linq;


namespace SoftTouch
{
    public struct NameComponent
    {
        public string Name;
    }
    public struct AgeComponent
    {
        public int Age;
    }
    public class NameProcessor : Processor<Query<NameComponent>>
    {
        public override void Update()
        {
            
        }        
    }
}