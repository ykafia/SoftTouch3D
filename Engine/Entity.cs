using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DXDebug.Engine.Components;

namespace DXDebug.Engine
{
    public struct EntityBase<TIndex, TComponentKind> 
        where TIndex : struct
    {
        public TIndex Index {get;set;}
        public List<TComponentKind> Archetype {get;set;} = new();
        public void Add(TComponentKind type) => Archetype.Add(type);

    }
    public interface IEntity{}

    public class Entity : IEntity
    {
        public long Index {get;set;}
        public Type[] ComponentTypes => Components.Keys.ToArray();

        public Dictionary<Type, object> Components = new();

        public EntityManager? Manager;
        
        public List<IComponentArray> Arrays = new();

        public Entity With<T>(T component) where T : struct
        {
            if(!typeof(T).GetInterfaces().Contains(typeof(IEntity)))
            {
                Components[typeof(T)] = component;
            }
            return this;
        }

        public void Build()
        {
            if(!Manager.Archetypes.TryGetValue(ComponentTypes, out var archetype))
            {
                archetype = new Archetype(ComponentTypes);
            }
            foreach(var e in Components)
            {
                var ctx = typeof(Archetype).GetMethod("AddComponent")?.MakeGenericMethod(e.Key);
                ctx.Invoke(archetype,new object[]{e.Value});
            }
            Manager[Index] = new ArchetypeRecord
            {
                Row = archetype.Length,
                Archetype = archetype
            };
        }

        public override string ToString() => "[" + Index.ToString() + " : <" + string.Join(",",ComponentTypes.Select(x => x.Name)) +">]";

    }
}