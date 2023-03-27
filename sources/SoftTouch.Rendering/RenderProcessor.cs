using SoftTouch.ECS;

namespace SoftTouch.Rendering;

public abstract class RenderProcessor : Processor
{
    public RenderProcessor()
    {

    }
    public virtual void Prepare(){}
    public virtual void Transform(){}
}

public class RenderProcessor<Q> : RenderProcessor
    where Q : Query, new()
{
    protected Q Entities {get; private set;}

    public override Processor With(World world)
    {
        World = world;
        Entities.With(world);
        return this;
    }
}
public class RenderProcessor<Q1,Q2> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
{
    protected Q1 Entities1 {get; private set;}
    protected Q2 Entities2 {get; private set;}

    public RenderProcessor()
    {
        Entities1 = new Q1();
        Entities2 = new Q2();
    }
    
    public override Processor With(World world)
    {
        World = world;
        Entities1.With(world);
        Entities2.With(world);
        return this;
    }
}
public class RenderProcessor<Q1,Q2,Q3> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
    where Q3 : Query, new()
{
    protected Q1 Entities1 {get; private set;}
    protected Q2 Entities2 {get; private set;}
    protected Q3 Entities3 {get; private set;}

    public RenderProcessor()
    {
        Entities1 = new Q1();
        Entities2 = new Q2();
        Entities3 = new Q3();
    }
    
    public override Processor With(World world)
    {
        World = world;
        Entities1.With(world);
        Entities2.With(world);
        Entities3.With(world);
        return this;
    }
}

public class RenderProcessor<Q1,Q2,Q3,Q4> : RenderProcessor
    where Q1 : Query, new()
    where Q2 : Query, new()
    where Q3 : Query, new()
    where Q4 : Query, new()
{
    protected Q1 Entities1 {get; private set;}
    protected Q2 Entities2 {get; private set;}
    protected Q3 Entities3 {get; private set;}
    protected Q4 Entities4 {get; private set;}

    public RenderProcessor()
    {
        Entities1 = new Q1();
        Entities2 = new Q2();
        Entities3 = new Q3();
        Entities4 = new Q4();
    }
    
    public override Processor With(World world)
    {
        World = world;
        Entities1.With(world);
        Entities2.With(world);
        Entities3.With(world);
        Entities4.With(world);
        return this;
    }
}