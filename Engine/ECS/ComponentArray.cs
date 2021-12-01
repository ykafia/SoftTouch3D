using System.Collections.Generic;
using System.Linq;

namespace WonkECS
{
    public interface IComponentArray 
    {
        string StringRepresentation();
        int GetLength();
    }
    public class ComponentArray<T> : IComponentArray where T : struct
    {
        public List<T> Elements = new();
        public void Add(T e) => Elements.Add(e);

        public void Remove(T e) => Elements.Remove(e);

        public T this[int i]
        {
            get{return Elements[i];}
            set{Elements[i] = value;}
        }

        public string StringRepresentation()
        {
            return string.Join("; ",Elements.Select(x => x.ToString()).ToList());
        }

        public int GetLength() => Elements.Count;
    }
}