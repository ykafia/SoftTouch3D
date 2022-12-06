using SoftTouch.ECS;

namespace SoftTouch.Rendering;

public abstract class RenderProcessor : Processor
{
    public virtual void Prepare(){}
    public virtual void Transform(){}
}

public class RenderProcessor<Q> : RenderProcessor
    where Q : Query, new()
{
        protected readonly Q query1;
        public RenderProcessor()
        {
            query1 = (Q)new Q().With(World);
        }
}
public class RenderProcessor<Q1,Q2> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
{
    protected readonly Q1 query1;
    protected readonly Q2 query2;
    public RenderProcessor()
    {
        query1 = (Q1)new Q1().With(World);
        query2 = (Q2)new Q2().With(World);
    }
}
public class RenderProcessor<Q1,Q2,Q3> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
    where Q3 : Query, new()
{
    protected readonly Q1 query1;
    protected readonly Q2 query2;
    protected readonly Q3 query3;
    public RenderProcessor()
    {
        query1 = (Q1)new Q1().With(World);
        query2 = (Q2)new Q2().With(World);
        query3 = (Q3)new Q3().With(World);
    }
}

public class RenderProcessor<Q1,Q2,Q3,Q4> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
    where Q3 : Query, new()
    where Q4 : Query, new()
{
    protected readonly Q1 query1;
    protected readonly Q2 query2;
    protected readonly Q3 query3;
    protected readonly Q4 query4;
    public RenderProcessor()
    {
        query1 = (Q1)new Q1().With(World);
        query2 = (Q2)new Q2().With(World);
        query3 = (Q3)new Q3().With(World);
        query4 = (Q4)new Q4().With(World);
    }
}