using System;
using Silk.NET.Windowing;
using SoftTouch.Graphics.Vulkan;
using Silk.NET.Maths;


namespace SoftTouch
{
    public class VKGame : IGame
    {
        IWindow window;

        GraphicsDevice Device;
        public bool EventBasedRendering = false;
        public bool framebufferResized = false;

        public VKGame() => InitWindow();
        private void InitWindow()
        {
            var opts = WindowOptions.DefaultVulkan;
            opts.IsEventDriven = EventBasedRendering;

            // Uncomment the line below to use SDL
            // Window.PrioritizeSdl();

            window = Window.Create(opts);
            window.Initialize(); // For safety the window should be initialized before querying the VkSurface

            if (window?.VkSurface is null)
            {
                throw new NotSupportedException("Windowing platform doesn't support Vulkan.");
            }

            // window.FramebufferResize += OnFramebufferResize;
        }

        private void InitVulkan()
        {
            Device = new GraphicsDevice();
            Device.CreateInstance(window);
            Device.GetPhysicalDevice();
            Device.CreateLogicalDevice();
            Device.CreateSwapChain(window);
            

        }
        private void OnFramebufferResize(Vector2D<int> size)
        {
            framebufferResized = true;
            // RecreateSwapChain();
            window.DoRender();
        }
        public void Run()
        {
            InitVulkan();
            window.Run();
        }
    }
}