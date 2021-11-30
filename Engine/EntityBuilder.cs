using System;
using System.Linq;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public class EntityBuilder : IEntity
    {
        public Entity? Entity;
        public HashSet<Type> ComponentTypes => Components.Keys.ToHashSet();

        public Dictionary<Type, object> Components = new();

        public EntityBuilder With<T>(T component) where T : struct
        {
            if(!typeof(T).GetInterfaces().Contains(typeof(IEntity)))
            {
                Components[typeof(T)] = component;
            }
            return this;
        }

        public void Build()
        {
            Archetype archetype = Entity.Manager.GenerateArchetypes(ComponentTypes);
            foreach(var e in Components)
            {
                var ctx = typeof(Archetype).GetMethod("AddComponent")?.MakeGenericMethod(e.Key);
                ctx.Invoke(archetype,new object[]{e.Value, Entity.Index});
            }
            Entity.Manager[Entity.Index] = new ArchetypeRecord
            {
                Row = archetype.Length,
                Archetype = archetype
            };
            Entity.Manager.BuildGraph();
        }

        public override string ToString() => "[" + Entity.Index.ToString() + " : <" + string.Join(",",ComponentTypes.Select(x => x.Name)) +">]";

    }
}