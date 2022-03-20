using System.Collections.Generic;
using Silk.NET.Vulkan;

namespace SoftTouch.Graphics.Vulkan
{
    public struct SwapChainSupportDetails 
    {
        public SurfaceCapabilitiesKHR capabilities;
        public SurfaceFormatKHR[] formats;
        public PresentModeKHR[] presentModes;
    };
}