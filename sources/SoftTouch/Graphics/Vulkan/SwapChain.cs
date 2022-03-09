using Silk.NET.Vulkan;

namespace SoftTouch.Graphics.Vulkan
{
    public class SwapChain
    {
        SwapchainKHR nativeSwap;
        SurfaceKHR nativeSurface;
        Image[]? images;

        ImageView[]? imageViews;
        Format imageFormat;
        Extent2D extent;
        Framebuffer[]? framebuffer;
        
        SwapchainKHR NativeSwap {get => nativeSwap; set {nativeSwap = value;}}
        SurfaceKHR Surface {get => nativeSurface; set {nativeSurface = value;}}
        ImageView[]? ImageViews {get => imageViews; set {imageViews = value;}}
        Image[]? Images {get => images; set {images = value;}}
        Format ImageFormat {get => imageFormat; set {imageFormat = value;}}
        Extent2D Extent {get => extent; set {extent = value;}}
        Framebuffer[]? Framebuffers {get => framebuffer; set {framebuffer = value;}}
    }
}