using Silk.NET.Vulkan;

namespace SoftTouch.Graphics.Vulkan
{
    public class GraphicsQueue
    {
        Queue presentation;
        Queue graphics;
        
        public Queue Presentation {get => presentation;}
        public Queue Graphics {get => graphics;}


        public GraphicsQueue(Vk api, QueueFamilyIndices indices, Device nativeDevice)
        {
            unsafe
            {
                fixed(Queue* g = &graphics)
                    api.GetDeviceQueue(nativeDevice, indices.GraphicsFamily.Value, 0, g);
                fixed(Queue* p = &presentation)
                    api.GetDeviceQueue(nativeDevice, indices.GraphicsFamily.Value, 0, p);
            }
            
        }
        
    }
}