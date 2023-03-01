using Silk.NET.Windowing;

namespace SoftTouch.Graphics.Tests
{
    public class InstanceTests
    {
        [Fact]
        public void CreateGraphicsState()
        {
            var window = Window.Create(
               new()
               {
                   API = GraphicsAPI.None,
                   FramesPerSecond = 60
               } 
            );
            var gfx = GraphicsState.GetOrCreate(window);
            
        }
    }
}