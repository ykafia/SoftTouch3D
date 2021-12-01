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
                    x => x.Apply( (NameComponent y) => {y.Name = "John2";} )
                );
        }        
    }
}