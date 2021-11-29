using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DXDebug.Engine.Components;

namespace DXDebug.Engine
{
    public class Archetype
    {
        public Dictionary<Type, IComponentArray> Storage = new();

        public List<Type> AType => Storage.Keys.ToList();
        public List<IComponentArray> ComponentArrays => Storage.Values.ToList();

        public int Length => Storage.Select(x => x.Value.GetLength()).Max();

        public Archetype(){}

        public Archetype(IEnumerable<Type> types)
        {
            foreach(var t in types)
                Storage[t] = Activator.CreateInstance(typeof(ComponentArray<>).MakeGenericType(t)) as IComponentArray;
        }

        public ComponentArray<T> GetComponentArray<T>() where T : struct
        {
            return (ComponentArray<T>)Storage[typeof(T)];
        }
        public void AddComponent<T>(T component) where T : struct
        {
            if(Storage.ContainsKey(typeof(T)))
                ((ComponentArray<T>)Storage[typeof(T)]).Add(component);
        }
        public void SetLastComponent<T>(T component) where T : struct
        {
            if(Storage.ContainsKey(typeof(T)))
                ((ComponentArray<T>)Storage[typeof(T)])[Storage.Count-1] = component;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Type : [");
            result.Append(string.Join(";",AType.Select(x => x.Name).ToList()));
            result.Append(']');
            result.AppendLine();
            result.Append("Storages : [");
            result.Append(string.Join(";",ComponentArrays.Select(x => x.StringRepresentation())));
            result.Append(']');
            return result.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Archetype archetype &&
                   EqualityComparer<Dictionary<Type, IComponentArray>>.Default.Equals(Storage, archetype.Storage);
                //    EqualityComparer<List<Type>>.Default.Equals(AType, archetype.AType) &&
                //    EqualityComparer<List<IComponentArray>>.Default.Equals(Components, archetype.Components) &&
                //    Length == archetype.Length;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Storage, AType, ComponentArrays, Length);
        }
    }
}