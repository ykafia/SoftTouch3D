using System.Linq;
using Silk.NET.Core;
using Silk.NET.Vulkan;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Windowing;

namespace SoftTouch.Graphics.Vulkan
{
    public class GraphicsSwapChain
    {
        SwapchainKHR nativeSwap;
        KhrSwapchain swapchain;
        SurfaceKHR surface;
        KhrSurface vkSurface;
        Image[]? images;

        ImageView[]? imageViews;
        Format imageFormat;
        Extent2D extent;
        Framebuffer[]? framebuffer;

        public SwapchainKHR NativeSwap { get => nativeSwap; set { nativeSwap = value; } }
        public KhrSwapchain Swap { get => swapchain; set { swapchain = value; } }
        
        public SurfaceKHR Surface { get => surface; set { surface = value; } }
        public KhrSurface VkSurface { get => vkSurface; set { vkSurface = value; } }
        
        public ImageView[]? ImageViews { get => imageViews; set { imageViews = value; } }
        public Image[]? Images { get => images; set { images = value; } }
        public Format ImageFormat { get => imageFormat; set { imageFormat = value; } }
        public Extent2D Extent { get => extent; set { extent = value; } }
        Framebuffer[]? Framebuffers { get => framebuffer; set { framebuffer = value; } }

        public void Initialize(Vk api, IWindow window, PhysicalDevice physicalDevice, Device device, QueueFamilyIndices indices)
        {
            var queueFamilyIndices = new uint[] { indices.GraphicsFamily.Value, indices.PresentFamily.Value };
            unsafe
            {
                SwapChainSupportDetails details = QuerySwapChainSupport(physicalDevice);

                var surfaceFormat = ChooseSwapSurfaceFormat(details.formats);
                var presentMode = ChooseSwapPresentMode(details.presentModes);
                var extent = ChooseSwapExtent(details.capabilities, window);

                uint imageCount = details.capabilities.MinImageCount + 1;

                if (details.capabilities.MaxImageCount > 0 && imageCount > details.capabilities.MaxImageCount)
                    imageCount = details.capabilities.MaxImageCount;

                var createInfoKHR = new SwapchainCreateInfoKHR
                {
                    SType = StructureType.SwapchainCreateInfoKhr,
                    Surface = surface,
                    MinImageCount = imageCount,
                    ImageFormat = surfaceFormat.Format,
                    ImageColorSpace = surfaceFormat.ColorSpace,
                    ImageExtent = extent,
                    ImageArrayLayers = 1,
                    ImageUsage = ImageUsageFlags.ImageUsageColorAttachmentBit
                };
            
                fixed (uint* pqf = queueFamilyIndices)
                {
                    if (indices.GraphicsFamily != indices.PresentFamily)
                    {
                        createInfoKHR =
                            createInfoKHR with
                            {
                                ImageSharingMode = SharingMode.Concurrent,
                                QueueFamilyIndexCount = 2,
                                PQueueFamilyIndices = pqf
                            };
                    }
                    else
                    {
                        createInfoKHR =
                            createInfoKHR with
                            {
                                ImageSharingMode = SharingMode.Exclusive,
                                QueueFamilyIndexCount = 0,
                                PQueueFamilyIndices = null
                            };
                    }
                    createInfoKHR = createInfoKHR with
                    {
                        PreTransform = details.capabilities.CurrentTransform,
                        CompositeAlpha = CompositeAlphaFlagsKHR.CompositeAlphaOpaqueBitKhr,
                        PresentMode = presentMode,
                        Clipped = new Bool32(true),
                        OldSwapchain = default
                    };
                    fixed(SwapchainKHR* pSwap = &nativeSwap)
                        swapchain.CreateSwapchain(device, &createInfoKHR, null, pSwap);
                }   
            }

        }


        public unsafe void InitializeTextures(Device device)
        {
            uint imageCount = 0;
            swapchain.GetSwapchainImages(device, nativeSwap,&imageCount,null);
            images = new Image[imageCount];
            swapchain.GetSwapchainImages(device, nativeSwap,&imageCount,images);
            
            imageViews = new ImageView[imageCount];

            

        }



        public unsafe SwapChainSupportDetails QuerySwapChainSupport(PhysicalDevice device)
        {
            var details = new SwapChainSupportDetails();
            vkSurface.GetPhysicalDeviceSurfaceCapabilities(device, surface, &details.capabilities);

            uint formatCount = 0;
            vkSurface.GetPhysicalDeviceSurfaceFormats(device, surface, &formatCount, null);

            if (formatCount > 0)
            {
                details.formats = new SurfaceFormatKHR[formatCount];
                vkSurface.GetPhysicalDeviceSurfaceFormats(device, surface, &formatCount, details.formats);
            }
            uint presentModeCount = 0;
            vkSurface.GetPhysicalDeviceSurfacePresentModes(device, surface, &presentModeCount, null);

            if (formatCount > 0)
            {
                details.presentModes = new PresentModeKHR[presentModeCount];
                vkSurface.GetPhysicalDeviceSurfacePresentModes(device, surface, &presentModeCount, details.presentModes);
            }


            return details;
        }
        private SurfaceFormatKHR ChooseSwapSurfaceFormat(SurfaceFormatKHR[] availableFormats)
        {
            return availableFormats.First(
                x =>
                    x.Format == Format.B8G8R8A8Srgb && x.ColorSpace == ColorSpaceKHR.ColorspaceSrgbNonlinearKhr

            );
        }
        private PresentModeKHR ChooseSwapPresentMode(PresentModeKHR[] availablePresentModes)
        {
            return availablePresentModes.Any(x => x == PresentModeKHR.PresentModeMailboxKhr) ?
                PresentModeKHR.PresentModeMailboxKhr : PresentModeKHR.PresentModeFifoKhr;
        }

        Extent2D ChooseSwapExtent(SurfaceCapabilitiesKHR capabilities, IWindow window)
        {
            if (capabilities.CurrentExtent.Width != uint.MaxValue)
            {
                return capabilities.CurrentExtent;
            }

            var actualExtent = new Extent2D
            { Height = (uint)window.FramebufferSize.Y, Width = (uint)window.FramebufferSize.X };
            actualExtent.Width = new[]
            {
                capabilities.MinImageExtent.Width,
                new[] {capabilities.MaxImageExtent.Width, actualExtent.Width}.Min()
            }.Max();
            actualExtent.Height = new[]
            {
                capabilities.MinImageExtent.Height,
                new[] {capabilities.MaxImageExtent.Height, actualExtent.Height}.Min()
            }.Max();

            return actualExtent;
        }
    }
}