using System;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public class ArchetypeEdges
    {
        public Dictionary<Type,Archetype> Add = new();
        public Dictionary<Type,Archetype> Remove = new();
    }
}