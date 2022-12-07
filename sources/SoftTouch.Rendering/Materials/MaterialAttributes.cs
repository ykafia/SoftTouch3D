// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.ComponentModel;
using SoftTouch.Graphics;
using WGPU.NET;

namespace Stride.Rendering.Materials
{
    public class MaterialAttributes : IMaterialAttributes
    {
        public MaterialAttributes()
        {
            CullMode = Wgpu.CullMode.Back;
            // Overrides = new MaterialOverrides();
        }

        public bool Enabled { get; set; } = true;

        public IMaterialTessellationFeature Tessellation { get; set; }

        public IMaterialDisplacementFeature Displacement { get; set; }

        public IMaterialSurfaceFeature Surface { get; set; }

        public IMaterialMicroSurfaceFeature MicroSurface { get; set; }

        public IMaterialDiffuseFeature Diffuse { get; set; }

        public IMaterialDiffuseModelFeature DiffuseModel { get; set; }


        public IMaterialSpecularFeature Specular { get; set; }


        public IMaterialSpecularModelFeature SpecularModel { get; set; }

        public IMaterialOcclusionFeature Occlusion { get; set; }

        public IMaterialEmissiveFeature Emissive { get; set; }


        public IMaterialSubsurfaceScatteringFeature SubsurfaceScattering { get; set; }

        public IMaterialTransparencyFeature Transparency { get; set; }

        // public MaterialOverrides Overrides { get; private set; }

        
        public Wgpu.CullMode CullMode { get; set; }

        
        public IMaterialClearCoatFeature ClearCoat { get; set; }

        // public void Visit(MaterialGeneratorContext context)
        // {
        //     if (!Enabled)
        //         return;

        //     // Push overrides of this attributes
        //     context.PushOverrides(Overrides);

        //     // Order is important, as some features are dependent on other
        //     // (For example, Specular can depend on Diffuse in case of Metalness)
        //     // We may be able to describe a dependency system here, but for now, assume 
        //     // that it won't change much so it is hardcoded

        //     // If Specular has energy conservative, copy this to the diffuse lambertian model
        //     // TODO: Should we apply it to any Diffuse Model?
        //     var isEnergyConservative = (Specular as MaterialSpecularMapFeature)?.IsEnergyConservative ?? false;

        //     var lambert = DiffuseModel as IEnergyConservativeDiffuseModelFeature;
        //     if (lambert != null)
        //     {
        //         lambert.IsEnergyConservative = isEnergyConservative;
        //     }

        //     // Diffuse - these 2 features are always used as a pair
        //     context.Visit(Diffuse);
        //     if (Diffuse != null)
        //         context.Visit(DiffuseModel);

        //     // Surface Geometry
        //     context.Visit(Tessellation);
        //     context.Visit(Displacement);
        //     context.Visit(Surface);
        //     context.Visit(MicroSurface);

        //     // Specular - these 2 features are always used as a pair
        //     context.Visit(Specular);
        //     if (Specular != null)
        //         context.Visit(SpecularModel);

        //     // Misc
        //     context.Visit(Occlusion);
        //     context.Visit(Emissive);
        //     context.Visit(SubsurfaceScattering);

        //     // If hair shading is enabled, ignore the transparency feature to avoid errors during shader compilation.
        //     // Allowing the transparency feature while hair shading is on makes no sense anyway.
        //     if (!(SpecularModel is MaterialSpecularHairModelFeature) &&
        //         !(DiffuseModel is MaterialDiffuseHairModelFeature))
        //     {
        //         context.Visit(Transparency);
        //     }

        //     context.Visit(ClearCoat);

        //     // Pop overrides
        //     context.PopOverrides();

        //     // Only set the cullmode to something 
        //     if (context.Step == MaterialGeneratorStep.GenerateShader && CullMode != CullMode.Back)
        //     {
        //         if (context.MaterialPass.CullMode == null)
        //         {
        //             context.MaterialPass.CullMode = CullMode;
        //         }
        //     }
        // }
    }
}
