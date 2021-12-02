using System;
using System.Collections.Generic;
using System.Linq;

namespace WonkECS
{

    public partial class ComponentArray
    {
        public virtual string StringRepresentation() => "";
        public virtual void AddComponents(List<object> components){}
        public virtual Type GetElementType() => GetType();
        public virtual void Merge(ComponentArray other){}
        public virtual ComponentArray EmptyFrom(ComponentArray array) => new();
        public virtual int GetLength() => 0;
        public virtual List<object> GetList() => new();
    }

    public class ComponentArray<T> : ComponentArray where T : struct
    {
        public List<T> Elements = new();
        public override int GetLength() => Elements.Count;

        public Type ElementType => typeof(T);


        public ComponentArray(T element)
        {
            this.Elements = new List<T>{element};
        }
        public ComponentArray(List<T> elements)
        {
            this.Elements = elements;
        }

        public void Add(T e) => Elements.Add(e);

        public void Remove(T e) => Elements.Remove(e);

        public T this[int i]
        {
            get{return Elements[i];}
            set{Elements[i] = value;}
        }

        public override Type GetElementType()
        {
            return ElementType;
        }

        public override string StringRepresentation()
        {
            return string.Join("; ",Elements.Select(x => x.ToString()).ToList());
        }
        public override void Merge(ComponentArray other)
        {
            if(other.GetElementType() == ElementType) Elements.AddRange(other.GetList().Cast<T>());
        }

        public override ComponentArray EmptyFrom(ComponentArray array) => new ComponentArray<T>(new List<T>());

    }
}