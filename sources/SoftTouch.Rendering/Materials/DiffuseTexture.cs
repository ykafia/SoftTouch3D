// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.ComponentModel;
using MemoryPack;
using SoftTouch.Graphics;
using SoftTouch.Graphics.WGPU;
using SoftTouch.Rendering.Materials.Futures;

namespace SoftTouch.Rendering.Materials;


public class DiffuseTexture : IMaterialDiffuseFeature
{
    public Texture Texture { get; set; }
    public Sampler Sampler { get; set; }
}

