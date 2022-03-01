using ECSharp;
using ECSharp.Arrays;
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
    public class NameProcessor : Processor<QueryEntity<NameComponent>>
    {
        public override void Update()
        {
            GetQuery1()
                .AsParallel()
                .ForAll(
                    x => 
                    {
                        for(int i = 0; i< x.Length; i++)
                            x.SetComponent(i,new NameComponent{Name = "John2"});
                    }
                );
        }        
    }
}