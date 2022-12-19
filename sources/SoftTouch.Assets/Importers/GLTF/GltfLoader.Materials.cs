using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SoftTouch.Assets;
using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SoftTouch.Rendering.Renderables;
using SoftTouch.Graphics;
using Image = SixLabors.ImageSharp.Image;

namespace SoftTouch.Assets.Importers.GLTF;

public static partial class MeshImporter
{
    // public static MaterialAsset? ExtractMaterial(ModelAsset asset, MeshPrimitive primitive)
    // {

    //     var material = primitive.Material;
    //     // if(material.FindChannel("BaseColor") != null)
    //     // {
    //     //     return new MaterialAsset(
    //     //         Image.Load<Rgba32>(material.FindChannel("BaseColor")?.Texture.PrimaryImage.Content.Content.ToArray()),
                
    //     //     );
    //     // }
    //     else return null;
    // }
}