using System;
using SoftTouch.ECS;
using Silk.NET.Windowing;
using SoftTouch.Graphics;
using SoftTouch.Assets;
using MessagePack;
using MessagePack.Resolvers;
using Silk.NET.Maths;
using MemoryPack;
using Zio;
using SoftTouch.Assets.Serialization.MemoryPack;
using SoftTouch.Graphics.SilkWrappers;

namespace SoftTouch.Games;

public abstract class Game : IGame
{
    IWindow window;
    GraphicsState Graphics= null!;
    GameWorld world;
    public Game()
    {
        world = new();
        window = Window.Create(
            new()
            {
                API = GraphicsAPI.None,
                FramesPerSecond = 60,
                Size = new(800,600),
                Title = "MyRenderer",
                IsVisible = true
            }
        );
        window.Load += OnLoad;
        window.Update += Update;
        window.Initialize();
    }
    public void Run()
    {
        while (!window.IsClosing)
        {
            window.Run();
        }
    }
    public void Update(double elapsed)
    {
        Task.WaitAll(
                Task.Run(() => world.Update()),
                Task.Run(world.Render)
            );
        world.Extract();
    }

    public void OnLoad()
    {        
        Graphics = GraphicsState.GetOrCreate(window);
    }
}
