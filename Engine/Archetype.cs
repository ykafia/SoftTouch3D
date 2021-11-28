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
        public List<IComponentArray> Components => Storage.Values.ToList();

        public int Length;

        public ComponentArray<T> GetComponentArray<T>() where T : struct
        {
            return (ComponentArray<T>)Storage[typeof(T)];
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Type : [");
            result.Append(string.Join(";",AType.Select(x => x.Name).ToList()));
            result.Append(']');
            result.AppendLine();
            result.Append("Storages : [");
            result.Append(string.Join(";",Components.Select(x => x.StringRepresentation())));
            result.Append(']');
            return result.ToString();
        }
    }
}