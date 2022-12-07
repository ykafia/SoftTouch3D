using System;
using WGPU.NET;
using System.Diagnostics;
using Silk.NET.GLFW;
using System.Runtime.InteropServices;
using System.IO;
using SoftTouch.ECS;
using Silk.NET.Windowing;
using SoftTouch.Graphics.WebGPU;
using SoftTouch.Assets;
using Zio.FileSystems;
using SoftTouch.Rendering;
using System.Threading.Tasks;
using SoftTouch.Graphics;
using MessagePack;
using MessagePack.Resolvers;
using Silk.NET.Maths;

namespace SoftTouch.Games;

public abstract class Game : IGame
{
    IWindow window;
    WGPUGraphics Graphics = new();
    GameWorld world;
    AssetManager assetManager;


    public Game(params IFormatterResolver[] resolvers)
    {
        
        var options = 
            MessagePackSerializerOptions.Standard.WithResolver(CompositeResolver.Create(resolvers))
            .WithCompression(MessagePackCompression.Lz4BlockArray);
        MessagePackSerializer.DefaultOptions = options;

        var buff = MessagePackSerializer.Serialize(Vector3D<float>.One);
        var des = MessagePackSerializer.Deserialize<Vector3D<float>>(buff);
        Console.WriteLine($"<{des.X}, {des.Y}, {des.Z}>");
        
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
        world.AddStartup<T>();
        return this;
    }

    public void Run()
    {
        while (!window.IsClosing)
        {
            Task.WaitAll(
                Task.Run(world.Update),
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
