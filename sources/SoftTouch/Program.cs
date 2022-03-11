using System;
using System.Linq;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using ECSharp;
using System.Collections.Generic;

namespace SoftTouch
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            IGame g = new VKGame();

            g.Run();
            var w = new World();
            var e = w.CreateEntity()
                .With(new NameComponent{Name = "John"})
                .With(new AgeComponent())
                .Build();
            w[e.Index].Remove<NameComponent>();     
        }
   }
}