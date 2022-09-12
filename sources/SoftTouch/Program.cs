using System;
using System.Linq;
using ECSharp;
using System.Collections.Generic;
using SPIRVCross;
using static SPIRVCross.SPIRV;
using SoftTouch.Graphics.WGPU;

namespace SoftTouch
{

    public class Program
    {
        public static void Main(string[] args)
        {

            IGame g = new WGPUGame();

            g.Run();
            // var w = new World();
            // var e = w.CreateEntity()
            //     .With(new NameComponent { Name = "John" })
            //     .With(new AgeComponent());
            // w[e.Entity.Index].Remove<NameComponent>();
        }
    }
}