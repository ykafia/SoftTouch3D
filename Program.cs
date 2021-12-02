using System;
using System.Linq;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using WonkECS;
using WonkECS.Components;
using System.Collections.Generic;

namespace DXDebug
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            // IGame g = new DXGame();
            // g.Run();

            var em = new World();
            em
                .CreateEntity()
                .With(new NameComponent{Name = "John"})
                .With(new HealthComponent{LifePoints = 100, Shield = 100})
                .Build();
            em
                .CreateEntity()
                .With(new NameComponent{Name = "Lola"})
                .Build();
            em
                .CreateEntity()
                .With(new NameComponent{Name = "Toto"})
                .Build();
            em[0].Remove<HealthComponent>();
            // em.Processors.Add(new NameProcessor());
            em.Update();
            var arrays = em.QueryArchetypes(new ArchetypeID(new List<Type> { typeof(NameComponent) }));
            em.Archetypes[new ArchetypeID(new HashSet<Type>{typeof(NameComponent)})].GetComponentArray<NameComponent>().Elements.ForEach(x => Console.WriteLine(x.Name));
        }
   }
}