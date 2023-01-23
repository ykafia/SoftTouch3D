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

        w1.Commands.Spawn(new NameComponent() { Name = "Martha" });
        w1.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform());
        w1.Commands.Spawn(new NameComponent() { Name = "Martha" }, 0);
        w1.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform(),
        (1, 5));
        w1.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform());

        w1.AddProcessor<NameProcessor>();
        w1.Start();

        w2 = new();

        w2.Commands.Spawn(
        new NameComponent() { Name = "Martha" });
        w2.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform());
        w2.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        0);
        w2.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform(),
        (1, 5));
        w2.Commands.Spawn(
        new NameComponent() { Name = "Martha" },
        new Transform());

        w2.AddProcessor<IterNameProcessor>();
        w2.Start();
    }
    public void QueryIter()
    {
        w2.Update(false);
    }
}

