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
            em
                .CreateEntity()
                .With(new NameComponent{Name = "John"})
                .With(new NameComponent{Name = "Johan"})
                .With(new HealthComponent{LifePoints = 100, Shield = 100})
                .Build();
            em
                .CreateEntity()
                .With(new NameComponent{Name = "Lola"})
                .Build();
            
            foreach(var e in em.Entities)
            {
                Console.WriteLine(e.Key + " : [" + e.Value + "]");
            }
            
        }
   }
}