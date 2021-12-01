using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace WonkECS
{
    public class Archetype
    {
        public Dictionary<Type, IComponentArray> Storage = new();
        public List<long> EntityID = new();

        public ArchetypeID ID = new();

        public ArchetypeEdges Edges = new();

        public static readonly Archetype Empty = new();

        public int Length => Storage.Select(x => x.Value.GetLength()).Max();

        public Archetype(){}

        public Archetype(ref ArchetypeID types)
        {
            ID = types;
            foreach(var t in types.Types)
                Storage[t] = Activator.CreateInstance(typeof(ComponentArray<>).MakeGenericType(t)) as IComponentArray;
        }

        public bool IsSupersetOf(Archetype t) => this.ID.IsSupersetOf(t.ID);
        public bool IsSubsetOf(Archetype t) => this.ID.IsSubsetOf(t.ID);
        public IEnumerable<Type> TypeIntersect(Archetype t) => this.ID.Intersect(t.ID);
        public IEnumerable<Type> TypeExcept(Archetype t) => this.ID.Except(t.ID);


        public void GetComponentArrayRef<T>(out ComponentArray<T> array ) where T : struct
        {
            array = (ComponentArray<T>)Storage[typeof(T)];
        }
        public ComponentArray<T> GetComponentArray<T>() where T : struct
        {
            GetComponentArrayRef(out ComponentArray<T> output);
            return output;
        }

        public void Apply<T>(Action<T> apply)
            where T : struct
        {
            for(int i = 0; i < Length; i++)
                apply(((ComponentArray<T>)Storage[typeof(T)])[i]);
        }


        public IComponentArray GetIComponentArray(Type t)
        {
            return Storage[t];
        }
        public void AddComponent<T>(ref T component, long entity) where T : struct
        {
            if(Storage.ContainsKey(typeof(T)))
            {
                ((ComponentArray<T>)Storage[typeof(T)]).Add(component);
                EntityID.Add(entity);
            }
        }

        public void RemoveEntity()
        {
            
        }
        public void SetLastComponent<T>(T component, long entity) where T : struct
        {
            if(Storage.ContainsKey(typeof(T)))
            {
                ((ComponentArray<T>)Storage[typeof(T)])[Storage.Count-1] = component;
                EntityID[^1] = entity;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Type : [");
            result.Append(string.Join(";",ID.Types?.Select(x => x.Name).ToList()??new List<string>()));
            result.Append(']');
            result.AppendLine();
            result.Append("Storages : [");
            result.Append(string.Join(";",Storage.Values.ToList().Select(x => x.StringRepresentation())));
            result.Append(']');
            return result.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Archetype archetype &&
                //    EqualityComparer<Dictionary<Type, IComponentArray>>.Default.Equals(Storage, archetype.Storage);
                   EqualityComparer<ArchetypeID>.Default.Equals(ID, archetype.ID);
                //    EqualityComparer<List<IComponentArray>>.Default.Equals(Components, archetype.Components) &&
                //    Length == archetype.Length;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}