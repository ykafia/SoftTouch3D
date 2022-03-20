namespace SoftTouch.Graphics.Vulkan
{
    public struct QueueFamilyIndices
        {
            public uint? GraphicsFamily { get; set; }
            public uint? PresentFamily { get; set; }

            public bool IsComplete()
            {
                return this.GraphicsFamily.HasValue && PresentFamily.HasValue;
            }
        }
}