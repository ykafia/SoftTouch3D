using SoftTouch.Components;
using SoftTouch.ECS;
using SoftTouch.Processors;

namespace SoftTouch;

public class TryQuery
{
    World w1;
    World w2;

    public TryQuery()
    {
        w1 = new();

        w1.CreateEntity()
        .With(new NameComponent(){Name = "Martha"});
        w1.CreateEntity()
        .With(new NameComponent(){Name = "Martha"})
        .With(new Transform());
        w1.CreateEntity()
        .With(new NameComponent(){Name = "Martha"})
        .With<int>();
        w1.CreateEntity()
        .With(new NameComponent(){Name = "Martha"})
        .With(new Transform())
        .With((1,5));
        w1.CreateEntity()
        .With(new NameComponent(){Name = "Martha"})
        .With(new Transform());

        w1.AddProcessor<NameProcessor>();
        w1.Start();

        w2 = new();

        w2.CreateEntity()
        .With(new NameComponent() { Name = "Martha" });
        w2.CreateEntity()
        .With(new NameComponent() { Name = "Martha" })
        .With(new Transform());
        w2.CreateEntity()
        .With(new NameComponent() { Name = "Martha" })
        .With<int>();
        w2.CreateEntity()
        .With(new NameComponent() { Name = "Martha" })
        .With(new Transform())
        .With((1, 5));
        w2.CreateEntity()
        .With(new NameComponent() { Name = "Martha" })
        .With(new Transform());

        w2.AddProcessor<IterNameProcessor>();
        w2.Start();
    }
    public void QueryIter()
    {
        w2.Update(false);
    }
}

