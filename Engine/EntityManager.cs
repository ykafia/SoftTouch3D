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

        public EntityBuilder CreateEntity()
        {
            var e = new EntityBuilder{Entity = new Entity{Index = Entities.Count, Manager = this}};
            Entities[e.Entity.Index] = new();
            return e;
        }

        public ArchetypeRecord GetOrCreateRecord(HashSet<Type> types, EntityBuilder e)
        {
            if(Archetypes.TryGetValue(types,out Archetype a))
            {
                return new ArchetypeRecord{Row = a.Length, Archetype = a};
            }
            else
            {
                throw new NotImplementedException("Cannot generate record");
            }
        }

        internal Archetype GenerateArchetypes(ref HashSet<Type> types)
        {
            if(!Archetypes.ContainsKey(types))
            {
                Archetypes.Add(types, new Archetype(ref types));
                return Archetypes[types];
            }
            else
                return Archetypes[types];
            
        }

        public void BuildGraph()
        {
            var stor = Archetypes.Values.ToList();
            foreach(var arch in Archetypes.Values)
            {
                stor.Where( x => x.IsSupersetOf(arch) && x.AType.Count == arch.AType.Count+1).Select(other => (arch.TypeIntersect(other).First(),other)).ToList().ForEach(x => arch.Edges.Add.Add(x.Item1,x.other));
                stor.Where( x => x.IsSubsetOf(arch) && x.AType.Count == arch.AType.Count-1).Select(other => (other.TypeIntersect(arch).First(),other)).ToList().ForEach(x => arch.Edges.Remove.Add(x.Item1,x.other));
            }
        }

        public List<Archetype> QueryArchetypes(HashSet<Type> types)
        {
            return Archetypes
                .Where(arch => arch.Value.AType.IsSubsetOf(types))
                .Select(arch => arch.Value)
                .ToList();
        }



        // public void Add(Entity entity) => Entities.Add(entity,new ArchetypeRecord{Archetype = new Archetype(entity.Archetype)});
        // public void Remove(Entity entity) => Entities.Remove(entity);

    }
}