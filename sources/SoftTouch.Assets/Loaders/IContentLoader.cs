using SoftTouch.Graphics.WGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets.Loaders;

public interface IContentLoader
{
    GraphicsState Gfx { get; }
    ContentManager ContentManager { get; }
}

public interface IContentLoader<TData> : IContentLoader
{
    public void Load(UPath path, out TData data);
}
