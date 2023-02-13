using System;
using SoftTouch.ECS;
using Silk.NET.Windowing;
using SoftTouch.Graphics.WebGPU;
using SoftTouch.Assets;
using MessagePack;
using MessagePack.Resolvers;
using Silk.NET.Maths;
using MemoryPack;
using Zio;
using SoftTouch.Assets.Serialization.MemoryPack;

namespace SoftTouch.Games;

public abstract class Game : IGame
{
    IWindow window;
    WGPUGraphics Graphics = WGPUGraphics.Instance;
    GameWorld world;
    AssetManager assetManager;


    public Game()
    {
        MemoryPackFormatterProvider.Register(new UPathFormatter());
        // MessagePackSerializer.DefaultOptions = SoftTouchResolver.Options;

        // window = Window.Create(WindowOptions.Default);
        // window.Initialize();
        // OnLoad();


        // world = new();
        // var fs = new PhysicalFileSystem();
        // var ss = new SubFileSystem(fs, fs.ConvertPathFromInternal("../../assets"));
        // assetManager = new(ss);
        // world.SetResource(assetManager);
        // world.SetResource(Graphics);

    }
    public Game With<T>()
        where T : Processor, new()
    {
        world.AddStartupProcessor<T>();
        return this;
    }

    public void Run()
    {
        while (!window.IsClosing)
        {
            Task.WaitAll(
                Task.Run(() => world.Update()),
                Task.Run(world.Render)
            );
            world.Extract();
        }
    }

    public void OnLoad()
    {
        Graphics.LoadWindow(window);
    }
}
