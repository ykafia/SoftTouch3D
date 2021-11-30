namespace DXDebug.Engine
{
    public partial class Processor<T> where T : IQueryEntity
    {
        public T QueryEntity;
        public virtual void Update(EntityManager Manager)
        {
            Manager.QueryArchetypes(QueryEntity.GetQueryType());
        }
    }
}