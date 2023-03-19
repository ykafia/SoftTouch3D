using Silk.NET.Windowing;
using SoftTouch.Graphics.WGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics;

public interface IGraphicsState<T> where T : class, IGraphicsState<T>
{
    static T gfxState { get; set; } = null!;

    public static virtual T GetOrCreate(IWindow? window = null)
    {
        if (gfxState is not null)
            return gfxState;
        gfxState = T.Create(window ?? throw new Exception("window is null"));
        return gfxState;
    }

    public static abstract T Create(IWindow w);
}

public class MyGraphicsState : IGraphicsState<MyGraphicsState>
{
    public static MyGraphicsState Create(IWindow w)
    {
        throw new NotImplementedException();
    }
}

public abstract class Game<T> where T : class, IGraphicsState<T>
{
    public IGraphicsState<T> gfx { get; init; }
}

public class MyGame : Game<MyGraphicsState>
{
    public MyGame()
    {
    }
}