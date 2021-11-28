using System;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using DXDebug.Engine;
using DXDebug.Engine.Components;

namespace DXDebug
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            // IGame g = new DXGame();
            // g.Run();

            var em = new EntityManager();

            // var ac = new Archetype();

            var e = new Entity{Index = 0};
            e.Add(typeof(NameComponent));
            e.Add(typeof(ParentComponent));
            e.Add(typeof(Entity));

            var ac = new Archetype(e.Archetype);

            var nameStorage = new ComponentArray<NameComponent>();
            nameStorage.Add(new NameComponent{Name = "Hello World"});
            ac.Components.Add(nameStorage);
            var parentStorage = new ComponentArray<ParentComponent>();
            parentStorage.Add(new ParentComponent{Parent = 0});
            ac.Components.Add(parentStorage);

            em.Add(e);
            Console.WriteLine(ac);
            
        }
   }
}