using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using static SoftTouch.Assets.ContentManager;
using SixLabors.ImageSharp.PixelFormats;

namespace SoftTouch.Assets.Loaders;

public class TextureLoader : ContentLoader<Texture>
{
    public override void Load(UPath path)
    {
        using var imageStream = Content.FileSystem.OpenFile(path, FileMode.Open, FileAccess.Read);
        var image = Image.Load(imageStream);
        // TODO: Create image
        //Gfx.Device.CreateTexture(path.FullName)
    }

    public override void Unload(UPath path)
    {
        throw new NotImplementedException();
    }
}
