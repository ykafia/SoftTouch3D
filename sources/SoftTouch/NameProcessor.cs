using SoftTouch.ECS;
using SoftTouch.ECS.Arrays;
using System.Linq;


namespace SoftTouch
{
    public struct NameComponent
    {
        public string Name;
        public NameComponent(string name)
        {
            this.Name = name;
        }
    }
    public struct AgeComponent
    {
        public int Age;
    }
    public class NameProcessor : Processor<Query<NameComponent>>
    {
        public override void Update()
        {
            //for (int i = 0; i < Entities1.Length; i++)
            //    Entities1[i].Component1.Name = "Anton Jobim";
        }
    }
    public class LastNameProcessor : Processor<Query<NameComponent>>
    {
        public override void Update()
        {
            foreach (var arch in World.QueryArchetypes(Entities1.ID))
            {
                for (int i = 0; i < arch.Length; i++)
                {
                    arch.SetComponent<NameComponent>(i, new("Lilicia"));
                }
            }
        }
    }
}