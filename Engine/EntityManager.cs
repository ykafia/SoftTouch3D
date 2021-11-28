using System;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public class EntityManager
    {
        public Dictionary<Entity,HashSet<Type>> Entities = new();

        public void Add(Entity entity) => Entities.Add(entity,entity.Archetype);
        public void Remove(Entity entity) => Entities.Remove(entity);
        
    }
}