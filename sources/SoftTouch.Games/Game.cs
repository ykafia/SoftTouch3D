using System;
using SoftTouch.ECS;
using Silk.NET.Windowing;
using SoftTouch.Graphics;
using SoftTouch.Assets;
using Silk.NET.Maths;
using MemoryPack;
using Zio;
using SoftTouch.Assets.Serialization.MemoryPack;
using SoftTouch.Graphics.WGPU;
using VYaml.Serialization;
using SoftTouch.Assets.Serialization.Yaml;

namespace SoftTouch.Games;

public delegate void InitYamlSerializer();


public abstract class Game : IGame
{
    protected static InitYamlSerializer InitYaml;

    IWindow window;
    GraphicsState Graphics= null!;
    GameWorld world;
    public Game(string? name = null)
    {
        var options = WindowOptions.Default;
        options.API                      = GraphicsAPI.None;
        options.Size                     = new Vector2D<int>(800, 600);
        options.FramesPerSecond          = 60;
        options.UpdatesPerSecond         = 60;
        options.Position                 = new Vector2D<int>(0, 0);
        options.Title                    = name ?? "SoftTouchGame";
        options.IsVisible                = true;
        options.ShouldSwapAutomatically  = false;
        options.IsContextControlDisabled = true;
        window = Window.Create(options);
        world = new();
        window.Load += OnLoad;
        window.Update += Update;
        window.Closing += Close;
        window.Initialize();
    }
    public void Run() => window.Run();

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
    public static void Close()
    {
        Console.WriteLine("Closing");
    }
}
