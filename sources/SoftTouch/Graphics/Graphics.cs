using SharpGLTF.Schema2;
using Silk.NET.GLFW;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using WGPU.NET;
using Image = SixLabors.ImageSharp.Image;
using WTexture = WGPU.NET.Texture;

namespace SoftTouch.Graphics.WGPU
{
    struct NativeWindow
    {
        public nint Hwnd;
        public nint HDC;
        public nint HInstance;

        public static implicit operator NativeWindow((nint, nint, nint) data) => new NativeWindow { Hwnd = data.Item1, HDC = data.Item2, HInstance = data.Item3 };
    }
    public unsafe class WGPUGraphics
    {
        Glfw glfw;
        WindowHandle* window;
        private Wgpu.SwapChainDescriptor swapChainDescriptor;
        SwapChain? swapChain;
        private Wgpu.TextureDescriptor depthTextureDescriptor;
        private WTexture depthTexture;
        private TextureView depthTextureView;
        int prevWidth;
        int prevHeight;
        private global::WGPU.NET.Buffer indexBuffer;
        private UniformBuffer uniformBufferData;
        private global::WGPU.NET.Buffer uniformBuffer;
        Device device;
        Adapter adapter;
        Surface surface;
        private RenderPipeline renderPipeline;
        private BindGroupLayout bindGroupLayout;
        private BindGroup bindGroup;
        private ShaderModule shader;
        private PipelineLayout pipelineLayout;
        private VertexState vertexState;
        private Wgpu.TextureFormat swapChainFormat;
        private ColorTargetState[] colorTargets;
        private Vertex[] vertices;
        private uint[] indices;
        private global::WGPU.NET.Buffer vertexBuffer;

        public static void ErrorCallback(Wgpu.ErrorType type, string message)
        {
            var _message = message.Replace("\\r\\n", "\n");

            Console.WriteLine($"{type}: {_message}");

            Debugger.Break();
        }

        public void LoadWindow()
        {
            glfw = GlfwProvider.GLFW.Value;
            if (!glfw.Init())
            {
                Console.WriteLine("GLFW failed to initialize");
                Console.ReadKey();
                return;
            }

            glfw.WindowHint(WindowHintClientApi.ClientApi, ClientApi.NoApi);
            window = glfw.CreateWindow(1920, 1080, "SDSL Testbed", null, null);

            if (window == null)
            {
                Console.WriteLine("Failed to open window");
                glfw.Terminate();
                Console.ReadKey();
                return;
            }

            var instance = new Instance();


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NativeWindow nativeWindow = new GlfwNativeWindow(glfw, window).Win32.Value;
                surface = instance.CreateSurfaceFromWindowsHWND(nativeWindow.HInstance, nativeWindow.Hwnd);


            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var (Display, Window) = new GlfwNativeWindow(glfw, window).X11.Value;
                surface = instance.CreateSurfaceFromXlibWindow(Display, (uint)Window);
            }
            else
            {
                var nativeWindow = new GlfwNativeWindow(glfw, window).Cocoa.Value;
                surface = instance.CreateSurfaceFromMetalLayer(nativeWindow);
            }


            adapter = default;

            instance.RequestAdapter(surface, default, default, (s, a, m) => adapter = a, Wgpu.BackendType.Vulkan);

            adapter.GetProperties(out Wgpu.AdapterProperties properties);


            device = default;

            adapter.RequestDevice((s, d, m) => device = d,
                limits: new RequiredLimits()
                {
                    Limits = new Wgpu.Limits()
                    {
                        maxBindGroups = 1
                    }
                },
                deviceExtras: new DeviceExtras
                {
                    Label = "Device"
                }
            );


            device.SetUncapturedErrorCallback(ErrorCallback);


            // Create vertices
            var model = SharpGLTF.Schema2.ModelRoot.Load("../../assets/models/Fox.glb");
            var prim = model.LogicalMeshes[0].Primitives[0];
            var cols = prim.GetVertexColumns();
            vertices = new Vertex[cols.Positions.Count];
            var rand = new Random();
            for(int i =0; i< cols.Positions.Count; i++)
            {
                vertices[i] = new(cols.Positions[i],new(rand.NextSingle(),rand.NextSingle(),rand.NextSingle(),1), cols.TexCoords0[i]);
            }
            // var vertices = prim.VertexAccessors["POSITION"].get
            // vertices = new Vertex[]
            // {
            //     new Vertex(new ( -1,-1,0), new (1,1,0,1), new (0,1)),
            //     new Vertex(new ( -1, 1,0), new (0,1,1,1), new (0,0)),
            //     new Vertex(new (  1, 1,0), new (1,0,1,1), new (1,0)),
            //     new Vertex(new (  1,-1,0), new (0,0,1,1), new (1,1)),

            // };
            indices = prim.GetTriangleIndices().SelectMany(x => new uint[]{(uint)x.A,(uint)x.B,(uint)x.C}).ToArray();

            //Create vert buffer

            vertexBuffer = device.CreateBuffer("VertexBuffer", true, (ulong)(vertices.Length * sizeof(Vertex)), Wgpu.BufferUsage.Vertex);

            {
                // Fill the vertex buffer
                Span<Vertex> mapped = vertexBuffer.GetMappedRange<Vertex>(0, vertices.Length);

                vertices.CopyTo(mapped);

                vertexBuffer.Unmap();
            }

            indexBuffer = device.CreateBuffer("IndexBuffer", true, (ulong)(indices.Length * sizeof(uint)), Wgpu.BufferUsage.Index);
            {
                Span<uint> mapped = indexBuffer.GetMappedRange<uint>(0, indices.Length);
                indices.CopyTo(mapped);
                indexBuffer.Unmap();
            }
            // Create uniform buffer
            uniformBufferData = new UniformBuffer
            {
                Transform = Matrix4x4.Identity
            };

            uniformBuffer = device.CreateBuffer("UniformBuffer", false, (ulong)sizeof(UniformBuffer), Wgpu.BufferUsage.Uniform | Wgpu.BufferUsage.CopyDst);


            // Prepare the texture
            var image = Image.Load<Rgba32>(Path.Combine("Resources", "WGPU-Logo.png"));

            // Define WTexture size
            var imageSize = new Wgpu.Extent3D
            {
                width = (uint)image.Width,
                height = (uint)image.Height,
                depthOrArrayLayers = 1
            };

            // Instantiate in gpu
            var imageTexture = device.CreateTexture("Image",
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

                device.GetQueue().WriteTexture<Rgba32>(
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
                        bytesPerRow = (uint)(sizeof(Rgba32) * image.Width),
                        offset = 0,
                        rowsPerImage = (uint)image.Height
                    },
                    writeSize: imageSize
                );
            }

            // Instantiate sampler
            var imageSampler = device.CreateSampler("ImageSampler",
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



            bindGroupLayout = device.CreateBindgroupLayout(null, new Wgpu.BindGroupLayoutEntry[] {
                new Wgpu.BindGroupLayoutEntry
                {
                    binding = 0,
                    buffer = new Wgpu.BufferBindingLayout
                    {
                        type = Wgpu.BufferBindingType.Uniform,

                    },
                    visibility = (uint)Wgpu.ShaderStage.Vertex,
                },
                new Wgpu.BindGroupLayoutEntry
                {
                    binding = 1,
                    sampler = new Wgpu.SamplerBindingLayout
                    {
                        type = Wgpu.SamplerBindingType.Filtering
                    },
                    visibility = (uint)Wgpu.ShaderStage.Fragment
                },
                new Wgpu.BindGroupLayoutEntry
                {
                    binding = 2,
                    texture = new Wgpu.TextureBindingLayout
                    {
                        viewDimension = Wgpu.TextureViewDimension.TwoDimensions,
                        sampleType = Wgpu.TextureSampleType.Float
                    },
                    visibility = (uint)Wgpu.ShaderStage.Fragment
                }
            });

            bindGroup = device.CreateBindGroup(null, bindGroupLayout, new BindGroupEntry[]
            {
                new BindGroupEntry
                {
                    Binding = 0,
                    Buffer = uniformBuffer
                },
                new BindGroupEntry
                {
                    Binding = 1,
                    Sampler = imageSampler
                },
                new BindGroupEntry
                {
                    Binding = 2,
                    TextureView = imageTexture.CreateTextureView()
                }
            });



            shader = device.CreateWgslShaderModule(
                label: "shader.wgsl",
                wgslCode: File.ReadAllText("shader.wgsl")
            );


            pipelineLayout = device.CreatePipelineLayout(
                label: null,
                new BindGroupLayout[]
                {
                    bindGroupLayout
                }
            );



            vertexState = new VertexState()
            {
                Module = shader,
                EntryPoint = "vs_main",
                bufferLayouts = new VertexBufferLayout[]
                {
                    new VertexBufferLayout
                    {
                        ArrayStride = (ulong)sizeof(Vertex),
                        Attributes = new Wgpu.VertexAttribute[]
                        {
							//position
							new Wgpu.VertexAttribute
                            {
                                format = Wgpu.VertexFormat.Float32x3,
                                offset = 0,
                                shaderLocation = 0
                            },
							//color
							new Wgpu.VertexAttribute
                            {
                                format = Wgpu.VertexFormat.Float32x4,
                                offset = (ulong)sizeof(Vector3), //right after positon
								shaderLocation = 1
                            },
							//uv
							new Wgpu.VertexAttribute
                            {
                                format = Wgpu.VertexFormat.Float32x2,
                                offset = (ulong)(sizeof(Vector3)+sizeof(Vector4)), //right after color
								shaderLocation = 2
                            }
                        }
                    }
                }
            };

            swapChainFormat = surface.GetPreferredFormat(adapter);

            colorTargets = new ColorTargetState[]
            {
                new ColorTargetState()
                {
                    Format = swapChainFormat,
                    BlendState = new Wgpu.BlendState()
                    {
                        color = new Wgpu.BlendComponent()
                        {
                            srcFactor = Wgpu.BlendFactor.One,
                            dstFactor = Wgpu.BlendFactor.Zero,
                            operation = Wgpu.BlendOperation.Add
                        },
                        alpha = new Wgpu.BlendComponent()
                        {
                            srcFactor = Wgpu.BlendFactor.One,
                            dstFactor = Wgpu.BlendFactor.Zero,
                            operation = Wgpu.BlendOperation.Add
                        }
                    },
                    WriteMask = (uint)Wgpu.ColorWriteMask.All
                }
            };

            var fragmentState = new FragmentState()
            {
                Module = shader,
                EntryPoint = "fs_main",
                colorTargets = colorTargets
            };

            renderPipeline = device.CreateRenderPipeline(
                label: "Render pipeline",
                layout: pipelineLayout,
                vertexState: vertexState,
                primitiveState: new Wgpu.PrimitiveState()
                {
                    topology = Wgpu.PrimitiveTopology.TriangleList,
                    frontFace = Wgpu.FrontFace.CCW,
                    cullMode = Wgpu.CullMode.None
                },
                multisampleState: new Wgpu.MultisampleState()
                {
                    count = 1,
                    mask = uint.MaxValue,
                    alphaToCoverageEnabled = false
                },
                depthStencilState: new Wgpu.DepthStencilState()
                {
                    format = Wgpu.TextureFormat.Depth32Float,
                    depthCompare = Wgpu.CompareFunction.Always,
                    stencilBack = new Wgpu.StencilFaceState
                    {
                        depthFailOp = Wgpu.StencilOperation.Keep,
                        failOp = Wgpu.StencilOperation.Keep,
                        passOp = Wgpu.StencilOperation.Keep,
                        compare = Wgpu.CompareFunction.Always
                    },
                    stencilFront = new Wgpu.StencilFaceState
                    {
                        depthFailOp = Wgpu.StencilOperation.Keep,
                        failOp = Wgpu.StencilOperation.Keep,
                        passOp = Wgpu.StencilOperation.Keep,
                        compare = Wgpu.CompareFunction.Always
                    }

                },
                fragmentState: fragmentState
            );





            glfw.GetWindowSize(window, out prevWidth, out prevHeight);

            swapChainDescriptor = new Wgpu.SwapChainDescriptor
            {
                usage = (uint)Wgpu.TextureUsage.RenderAttachment,
                format = swapChainFormat,
                width = (uint)prevWidth,
                height = (uint)prevHeight,
                presentMode = Wgpu.PresentMode.Fifo
            };

            swapChain = device.CreateSwapChain(surface, swapChainDescriptor);

            depthTextureDescriptor = new Wgpu.TextureDescriptor
            {
                label = "Depth Buffer",
                usage = (uint)Wgpu.TextureUsage.RenderAttachment,
                dimension = Wgpu.TextureDimension.TwoDimensions,
                size = new Wgpu.Extent3D
                {
                    width = (uint)prevWidth,
                    height = (uint)prevHeight,
                    depthOrArrayLayers = 1
                },
                format = Wgpu.TextureFormat.Depth32Float,
                mipLevelCount = 1,
                sampleCount = 1
            };

            depthTexture = device.CreateTexture(in depthTextureDescriptor);
            depthTextureView = depthTexture.CreateTextureView();
        }

        public void Render()
        {
            Span<UniformBuffer> uniformBufferSpan = stackalloc UniformBuffer[1];
            var startTime = DateTime.Now;

            var lastFrameTime = startTime;
            while (!glfw.WindowShouldClose(window))
            {
                glfw.GetCursorPos(window, out double mouseX, out double mouseY);
                glfw.GetWindowSize(window, out int width, out int height);

                if ((width != prevWidth || height != prevHeight) && width != 0 && height != 0)
                {
                    prevWidth = width;
                    prevHeight = height;
                    swapChainDescriptor.width = (uint)width;
                    swapChainDescriptor.height = (uint)height;

                    depthTextureDescriptor.size.width = (uint)width;
                    depthTextureDescriptor.size.height = (uint)height;

                    swapChain = device.CreateSwapChain(surface, swapChainDescriptor);

                    depthTexture.DestroyResource();
                    depthTexture = device.CreateTexture(depthTextureDescriptor);
                    depthTextureView = depthTexture.CreateTextureView();
                }



                var currentTime = DateTime.Now;

                TimeSpan duration = currentTime - startTime;





                Vector2 nrmMouseCoords = new Vector2(
                    (float)(mouseX * 1 - prevWidth * 0.5f) / prevWidth,
                    (float)(mouseY * 1 - prevHeight * 0.5f) / prevHeight
                );


                uniformBufferData.Transform =
                Matrix4x4.CreateRotationY(
                    MathF.Sign(nrmMouseCoords.X) * (MathF.Log(Math.Abs(nrmMouseCoords.X) + 1)) * 0.9f
                ) *
                Matrix4x4.CreateRotationX(
                    MathF.Sign(nrmMouseCoords.Y) * (MathF.Log(Math.Abs(nrmMouseCoords.Y) + 1)) * 0.9f
                ) *
                Matrix4x4.CreateScale(
                    (float)(1 + 0.1 * Math.Sin(duration.TotalSeconds * 2.0))
                ) *
                Matrix4x4.CreateTranslation(0, 0, -3)
                ;

                uniformBufferData.Transform *= CreatePerspective(MathF.PI / 4f, (float)prevWidth / prevHeight, 0.01f, 1000);




                var nextTexture = swapChain.GetCurrentTextureView();

                if (nextTexture == null)
                {
                    Console.WriteLine("Could not acquire next swap chain texture");
                    return;
                }

                var encoder = device.CreateCommandEncoder("Command Encoder");

                var renderPass = encoder.BeginRenderPass(
                    label: null,
                    colorAttachments: new RenderPassColorAttachment[]
                    {
                    new RenderPassColorAttachment()
                    {
                        view = nextTexture,
                        resolveTarget = default,
                        loadOp = Wgpu.LoadOp.Clear,
                        storeOp = Wgpu.StoreOp.Store,
                        clearValue = new Wgpu.Color() { r = 0, g = 0.02f, b = 0.1f, a = 1 }
                    }
                    },
                    depthStencilAttachment: new RenderPassDepthStencilAttachment
                    {
                        View = depthTextureView,
                        DepthLoadOp = Wgpu.LoadOp.Clear,
                        DepthStoreOp = Wgpu.StoreOp.Store,
                        DepthClearValue = 0f,
                        StencilLoadOp = Wgpu.LoadOp.Clear,
                        StencilStoreOp = Wgpu.StoreOp.Discard
                    }
                );

                renderPass.SetPipeline(renderPipeline);

                renderPass.SetBindGroup(0, bindGroup, Array.Empty<uint>());
                renderPass.SetIndexBuffer(indexBuffer,Wgpu.IndexFormat.Uint32,0,(ulong)(indices.Length * sizeof(uint)));
                renderPass.SetVertexBuffer(0, vertexBuffer, 0, (ulong)(vertices.Length * sizeof(Vertex)));
                renderPass.DrawIndexed((uint)indices.Length,1,0,0,0);
                renderPass.End();



                var queue = device.GetQueue();

                uniformBufferSpan[0] = uniformBufferData;

                queue.WriteBuffer<UniformBuffer>(uniformBuffer, 0, uniformBufferSpan);

                var commandBuffer = encoder.Finish(null);

                queue.Submit(new CommandBuffer[]
                {
                    commandBuffer
                });

                swapChain.Present();


                glfw.PollEvents();
            }
        }

        public void Clean()
        {
            glfw.DestroyWindow(window);
            glfw.Terminate();
        }
        private static Matrix4x4 CreatePerspective(float fov, float aspectRatio, float near, float far)
        {
            if (fov <= 0.0f || fov >= MathF.PI)
                throw new ArgumentOutOfRangeException(nameof(fov));

            if (near <= 0.0f)
                throw new ArgumentOutOfRangeException(nameof(near));

            if (far <= 0.0f)
                throw new ArgumentOutOfRangeException(nameof(far));

            float yScale = 1.0f / MathF.Tan(fov * 0.5f);
            float xScale = yScale / aspectRatio;

            Matrix4x4 result;

            result.M11 = xScale;
            result.M12 = result.M13 = result.M14 = 0.0f;

            result.M22 = yScale;
            result.M21 = result.M23 = result.M24 = 0.0f;

            result.M31 = result.M32 = 0.0f;
            var negFarRange = float.IsPositiveInfinity(far) ? -1.0f : far / (near - far);
            result.M33 = negFarRange;
            result.M34 = -1.0f;

            result.M41 = result.M42 = result.M44 = 0.0f;
            result.M43 = near * negFarRange;

            return result;
        }
    }
}