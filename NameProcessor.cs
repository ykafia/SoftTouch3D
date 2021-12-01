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
                        var array = x.GetComponentArray<NameComponent>();
                        for(int i = 0; i< x.Length; i++)
                            array[i] = array[i] with {Name = "John2"}; 
                    }
                );
        }        
    }
}