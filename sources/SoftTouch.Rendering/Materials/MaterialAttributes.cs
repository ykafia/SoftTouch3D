// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.ComponentModel;
using SoftTouch.Graphics;
using WGPU.NET;

namespace SoftTouch.Rendering.Materials;



public class MaterialData
{

    public Texture Texture {get;set;}
    public Sampler Sampler {get;set;}

    public MaterialData(Texture texture, Sampler sampler)
    {
        Texture = texture;
        Sampler = sampler;
    }
}
public class MaterialAttributes
{
    public MaterialData Diffuse {get;set;}
}

