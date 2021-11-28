using System;
using System.Collections.Generic;

namespace DXDebug.Engine
{
    public class EntityManager
    {
        public Dictionary<long,ArchetypeRecord> Entities = new();

        public Dictionary<Type[],Archetype> Archetypes = new();

        public ArchetypeRecord this[long id]
        {
            get => Entities[id];
            set {Entities[id] = value;}
        }


        public Entity CreateEntity()
        {
            var e = new Entity{Index = Entities.Count, Manager = this};
            Entities[e.Index] = new();
            return e;
        }

        public ArchetypeRecord GetOrCreateRecord(Type[] types, Entity e)
        {
            if(Archetypes.TryGetValue(types,out Archetype a))
            {
                return new ArchetypeRecord{Row = a.Length, Archetype = a};
            }
            else 
            {
                Archetype? newAt = new();
                foreach(var t in types)
                {
                    object? array = Activator.CreateInstance(typeof(ComponentArray<>).MakeGenericType(t));
                    
                    newAt.Storage[t] =  array as IComponentArray;
                }
                Archetypes[types] = newAt;
                return new ArchetypeRecord{Row = 0, Archetype = newAt};
            }
        }

        

        // public void Add(Entity entity) => Entities.Add(entity,new ArchetypeRecord{Archetype = new Archetype(entity.Archetype)});
        // public void Remove(Entity entity) => Entities.Remove(entity);
        
    }
}