using SoftTouch.Graphics.WGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.WebGPU;
using Silk.NET.Windowing;

namespace SoftTouch
{

    public delegate void Notify();  // delegate

    internal class BufferRWTest
    {
        public static void Test(GraphicsState state)
        {


            var tex = state.Device.CreateTexture("myTex",
                new()
                {
                    Dimension = TextureDimension.TextureDimension2D,
                    Format = TextureFormat.Rgba8Uint,
                    MipLevelCount = 1,
                    Usage = TextureUsage.CopySrc | TextureUsage.CopyDst,
                    Size = new(8,8,1),
                    SampleCount = 1,
                }
            );
            //Console.WriteLine("Width is " + tex.Width);
            var buff = state.Device.CreateBuffer("myBuff",
                new()
                {
                    MappedAtCreation = true,
                    Size = 8*8,
                    Usage = BufferUsage.MapWrite | BufferUsage.CopySrc
                }
            );
            //buff.Unmap();

            var span = buff.GetMappedRange<byte>(0, 16);
            span.Fill(1);
            var span2 = buff.GetMappedRange<byte>(0,16);

            var x = 0;

        }
    }
}
