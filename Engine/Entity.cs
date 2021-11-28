using System;
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

    public struct Entity : IEntity
    {
        public long Index {get;set;}
        public HashSet<Type> Archetype {get;set;} = new();
        public HashSet<InstanceOfComponent> Instances {get;set;} = new();
        public void Add(Type t)
        {
            if(!t.GetInterfaces().Contains(typeof(IEntity)))
                Archetype.Add(t);
        }

        public override string ToString() => "[" + Index.ToString() + " : <" + string.Join(",",Archetype.Select(x => x.Name)) +">]";

    }
}