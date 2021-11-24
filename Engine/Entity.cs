using System;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public partial class EntityBase<TIndex, TComponentKind> where TIndex : struct
    {
        public TIndex Index {get;set;}
        public List<TComponentKind> Archetype {get;set;} = new();
        public void Add(TComponentKind type) => Archetype.Add(type);

    }

    public partial class Entity<TIndex> : EntityBase<TIndex, Type> where TIndex : struct {}
}