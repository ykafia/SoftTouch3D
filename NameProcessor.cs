using WonkECS;
using WonkECS.Components;

namespace DXDebug
{
    public class NameProcessor : Processor<QueryEntity<NameComponent>>
    {
        public override void Update(EntityManager Manager)
        {
            Manager.QueryArchetypes(QueryEntity.GetQueryType())
                .ForEach(
                    x => 
                    {
                        x.GetComponentArrayRef(out ComponentArray<NameComponent> array);
                        for(int i = 0; i< x.Length; i++)
                            x.SetComponent(i,new NameComponent{Name = "John2"});
                    }
                );
        }        
    }
}