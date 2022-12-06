using SoftTouch.Graphics.WGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace SoftTouch.Assets;

public class ImageAsset : IAsset<ImageAsset>
{
    public Image<Rgba32> ImageTexture { get; private set; }

    internal ImageAsset(Image<Rgba32> picture){
        ImageTexture = picture;
    }
    public static ImageAsset Load(in UPath path, IFileSystem fs)
    {
        if (fs.FileExists(path) && path.GetExtensionWithDot() == ".png")
        {
            var image = Image.Load<Rgba32>(fs.OpenFile(path,FileMode.Open,FileAccess.Read));
            return new ImageAsset(image);
        }
        else
            throw new Exception("Not a .png file");
    }
    public static void Unload(ImageAsset asset)
    {
        asset.Unload();
    }

    public void Unload()
    {
        ImageTexture.Dispose();
    }
}