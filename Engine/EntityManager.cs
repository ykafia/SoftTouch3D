using System;
using System.Collections.Generic;
using System.Linq;

namespace DXDebug.Engine
{
    public class EntityManager
    {
        public Dictionary<long,ArchetypeRecord> Entities = new();

        public Dictionary<HashSet<Type>,Archetype> Archetypes = new();

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

        public ArchetypeRecord GetOrCreateRecord(HashSet<Type> types, Entity e)
        {
            if(Archetypes.TryGetValue(types,out Archetype a))
            {
                return new ArchetypeRecord{Row = a.Length, Archetype = a};
            }
            else
            {
                throw new NotImplementedException("Cannot generate record");
            }
            // else 
            // {
            //     Archetype? newAt = new();
            //     foreach(var t in types)
            //     {
            //         object? array = Activator.CreateInstance(typeof(ComponentArray<>).MakeGenericType(t));
                    
            //         newAt.Storage[t] =  array as IComponentArray;
            //     }
            //     Archetypes[types] = newAt;
            //     return new ArchetypeRecord{Row = 0, Archetype = newAt};
            // }
        }

        internal Archetype GenerateArchetypes(HashSet<Type> types)
        {
            if(!Archetypes.ContainsKey(types))
            {
                var ts = Combinations(types).ToList();
                foreach(var t in ts)
                {
                    var th = t.ToHashSet();
                    if(!Archetypes.ContainsKey(th))
                        Archetypes.Add(th, new Archetype(t));
                }
                Archetypes.Add(types, new Archetype(types));
                return Archetypes[types];
            }
            else
            {
                return Archetypes[types];
            }
            
        }
        public static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source) {
            if (null == source)
                throw new ArgumentNullException(nameof(source));

            T[] data = source.ToArray();

            return Enumerable
                .Range(0, 1 << (data.Length))
                .Select(index => data
                .Where((v, i) => (index & (1 << i)) != 0)
                .ToArray());
        }



        // public void Add(Entity entity) => Entities.Add(entity,new ArchetypeRecord{Archetype = new Archetype(entity.Archetype)});
        // public void Remove(Entity entity) => Entities.Remove(entity);

    }
}