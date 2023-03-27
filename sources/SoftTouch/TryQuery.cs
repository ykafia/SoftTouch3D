using SoftTouch.Components;
using SoftTouch.ECS;
using SoftTouch.Processors;

namespace SoftTouch;

public class TryQuery
{
    World w1;

    public TryQuery()
    {
        w1 = new();

        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }).With<Transform>();
        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }, new Transform());
        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }, default(int));
        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }, new Transform(), (1, 5));
        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }, new Transform());


        static void WithoutForeach(Query<NameComponent> q1)
        {
            var iter = q1.GetEnumerator();
            while (iter.MoveNext())
            {
                var current = iter.Current;
                current.Set<NameComponent>(new("Kujo Jolyne"));
            }
        }

        //w1.AddProcessor((Query<NameComponent> q) => WithoutForeach(q));
        //w1.Start();
    }
    public void QueryIter()
    {
        for(int i =0; i < 10; i++)
            w1.Update(false);
    }
}

