using SoftTouch.ECS;
using SoftTouch.Assets;
using SoftTouch.Components;
using SoftTouch.Graphics.WebGPU;
using System;
using System.Linq;
using Silk.NET.Maths;
using System.Runtime.InteropServices;
using WGPU.NET;
using SoftTouch.Rendering;

namespace SoftTouch.Processors;

public class FoxMeshProcessor : RenderProcessor<Query<Transform, GlobalTransform, ModelComponent>, Query<Camera, GlobalTransform>>
{

    PipelineLayout Layout;
    private BindGroupLayout bindGroupLayout;
    private BindGroup bindGroup;
    private ShaderModule shader;
    private PipelineLayout pipelineLayout;
    private VertexState vertexState;
    private FragmentState fragmentState;

    public override void Update()
    {
        var graphics = World.GetResource<WGPUGraphics>();
        (var camera, var cameraPos) = query2.QueriedArchetypes.First()[0].Get<Camera, GlobalTransform>();
        (var pos, var worldPos, var model) = query1.QueriedArchetypes.First()[0].Get<Transform, GlobalTransform, ModelComponent>();
        cameraPos.ToMatrix(out var cameraWMat);
        worldPos.ToMatrix(out var meshWMat);
        // var uniformBufferData = new UniformBuffer
        // {
        //     Transform = meshWMat
        // };

        // var uniformBuffer = graphics.Device.CreateBuffer("UniformBuffer", false, (ulong)Marshal.SizeOf(typeof(UniformBuffer)), Wgpu.BufferUsage.Uniform | Wgpu.BufferUsage.CopyDst);

        // if(bindGroup != null)
        //     CreatePipeline(graphics, uniformBuffer,model.Model);
        
        // var swapChainFormat = graphics.Surface.GetPreferredFormat(graphics.Adapter);

        // var colorTargets = new ColorTargetState[]
        // {
        //         new ColorTargetState()
        //         {
        //             Format = swapChainFormat,
        //             BlendState = new Wgpu.BlendState()
        //             {
        //                 color = new Wgpu.BlendComponent()
        //                 {
        //                     srcFactor = Wgpu.BlendFactor.One,
        //                     dstFactor = Wgpu.BlendFactor.Zero,
        //                     operation = Wgpu.BlendOperation.Add
        //                 },
        //                 alpha = new Wgpu.BlendComponent()
        //                 {
        //                     srcFactor = Wgpu.BlendFactor.One,
        //                     dstFactor = Wgpu.BlendFactor.Zero,
        //                     operation = Wgpu.BlendOperation.Add
        //                 }
        //             },
        //             WriteMask = (uint)Wgpu.ColorWriteMask.All
        //         }
        // };

        // fragmentState = new FragmentState()
        // {
        //     Module = shader,
        //     EntryPoint = "fs_main",
        //     colorTargets = colorTargets
        // };

    }


    public void CreatePipeline(WGPUGraphics graphics, WGPU.NET.Buffer uniformBuffer, ModelAsset model)
    {
        // bindGroupLayout = graphics.Device.CreateBindgroupLayout(null, new Wgpu.BindGroupLayoutEntry[] {
        //         new Wgpu.BindGroupLayoutEntry
        //         {
        //             binding = 0,
        //             buffer = new Wgpu.BufferBindingLayout
        //             {
        //                 type = Wgpu.BufferBindingType.Uniform,

        //             },
        //             visibility = (uint)Wgpu.ShaderStage.Vertex,
        //         },
        //         new Wgpu.BindGroupLayoutEntry
        //         {
        //             binding = 1,
        //             sampler = new Wgpu.SamplerBindingLayout
        //             {
        //                 type = Wgpu.SamplerBindingType.Filtering
        //             },
        //             visibility = (uint)Wgpu.ShaderStage.Fragment
        //         },
        //         new Wgpu.BindGroupLayoutEntry
        //         {
        //             binding = 2,
        //             texture = new Wgpu.TextureBindingLayout
        //             {
        //                 viewDimension = Wgpu.TextureViewDimension.TwoDimensions,
        //                 sampleType = Wgpu.TextureSampleType.Float
        //             },
        //             visibility = (uint)Wgpu.ShaderStage.Fragment
        //         }
        //     });

        // bindGroup = graphics.Device.CreateBindGroup(null, bindGroupLayout, new BindGroupEntry[]
        // {
        //         new BindGroupEntry
        //         {
        //             Binding = 0,
        //             Buffer = uniformBuffer
        //         },
        //         new BindGroupEntry
        //         {
        //             Binding = 1,
        //             Sampler = model.Sampler
        //         },
        //         new BindGroupEntry
        //         {
        //             Binding = 2,
        //             TextureView = model.Diffuse.CreateTextureView()
        //         }
        // });



        // var shaderAsset = (ShaderAsset)World.GetResource<AssetManager>().Load<ShaderAsset>("/shaders/shader.wgsl");
        // shader =  graphics.Device.CreateWgslShaderModule("shader", shaderAsset.Module);

        // pipelineLayout = graphics.Device.CreatePipelineLayout(
        //     label: null,
        //     new BindGroupLayout[]
        //     {
        //             bindGroupLayout
        //     }
        // );



        // vertexState = new VertexState()
        // {
        //     Module = shader,
        //     EntryPoint = "vs_main",
        //     bufferLayouts = new VertexBufferLayout[]
        //     {
        //             new VertexBufferLayout
        //             {
        //                 // ArrayStride = model.Meshes.First().VertexBuffer.SizeInBytes,
        //                 Attributes = new Wgpu.VertexAttribute[]
        //                 {
		// 					//position
		// 					new Wgpu.VertexAttribute
        //                     {
        //                         format = Wgpu.VertexFormat.Float32x3,
        //                         offset = 0,
        //                         shaderLocation = 0
        //                     },
		// 					//color
		// 					new Wgpu.VertexAttribute
        //                     {
        //                         format = Wgpu.VertexFormat.Float32x4,
        //                         offset = (ulong)Marshal.SizeOf(typeof(Vector3D<float>)), //right after positon
		// 						shaderLocation = 1
        //                     },
		// 					//uv
		// 					new Wgpu.VertexAttribute
        //                     {
        //                         format = Wgpu.VertexFormat.Float32x2,
        //                         offset = (ulong)(Marshal.SizeOf(typeof(Vector3D<float>))+Marshal.SizeOf(typeof(Vector4D<float>))), //right after color
		// 						shaderLocation = 2
        //                     }
        //                 }
        //             }
        //     }
        // };

        
    }
}