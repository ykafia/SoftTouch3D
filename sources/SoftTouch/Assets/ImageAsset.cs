using SoftTouch.Graphics.WGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace SoftTouch.Assets;

public class ImageAsset : IGraphicsAsset<ImageAsset>
{
    public required Texture ImageTexture { get; init; }
    public required Sampler Sampler { get; init; }
    public static ImageAsset Load(in UPath path, IFileSystem fs, WGPUGraphics graphics)
    {
        if (fs.FileExists(path) && path.GetExtensionWithDot() == ".png")
        {
            var image = Image.Load<Rgba32>(fs.OpenFile(path,System.IO.FileMode.Open,System.IO.FileAccess.Read));
            var imageSize = new Wgpu.Extent3D
            {
                width = (uint)image.Width,
                height = (uint)image.Height,
                depthOrArrayLayers = 1
            };

            // Instantiate in gpu
            var imageTexture = graphics.Device.CreateTexture("Image",
                usage: Wgpu.TextureUsage.TextureBinding | Wgpu.TextureUsage.CopyDst,
                dimension: Wgpu.TextureDimension.TwoDimensions,
                size: imageSize,
                format: Wgpu.TextureFormat.RGBA8Unorm,
                mipLevelCount: 1,
                sampleCount: 1
            );

            {
                // Send data to gpu
                Span<Rgba32> pixels = new Rgba32[image.Width * image.Height];

                image.CopyPixelDataTo(pixels);

                graphics.Device.GetQueue().WriteTexture<Rgba32>(
                    destination: new ImageCopyTexture
                    {
                        Aspect = Wgpu.TextureAspect.All,
                        MipLevel = 0,
                        Origin = default,
                        Texture = imageTexture
                    },
                    data: pixels,
                    dataLayout: new Wgpu.TextureDataLayout
                    {
                        bytesPerRow = (uint)(sizeof(byte) * 4 * image.Width),
                        offset = 0,
                        rowsPerImage = (uint)image.Height
                    },
                    writeSize: imageSize
                );
            }

            // Instantiate sampler
            var imageSampler = graphics.Device.CreateSampler("ImageSampler",
                addressModeU: Wgpu.AddressMode.ClampToEdge,
                addressModeV: Wgpu.AddressMode.ClampToEdge,
                addressModeW: default,

                magFilter: Wgpu.FilterMode.Linear,
                minFilter: Wgpu.FilterMode.Linear,
                mipmapFilter: Wgpu.MipmapFilterMode.Linear,

                lodMinClamp: 0,
                lodMaxClamp: 1,
                compare: default,

                maxAnisotropy: 1
            );
            return new ImageAsset{ImageTexture = imageTexture, Sampler = imageSampler};
            // return new ShaderAsset{ Module = graphics.Device.CreateWgslShaderModule("shader",fs.ReadAllText(path))};
        }
        else
            throw new Exception("Not a wgsl file");
    }
    public static void Unload(ImageAsset asset)
    {
        asset.Unload();
    }

    public void Unload()
    {
        ImageTexture.DestroyResource();
        Sampler.FreeHandle();
        ImageTexture.FreeHandle();
    }
}