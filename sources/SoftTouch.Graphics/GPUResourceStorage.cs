using SoftTouch.Graphics.WGPU;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace SoftTouch.Graphics;

public class GPUResources<T> : IDictionary<string, T>
    where T : struct, IGraphicsObject
{

    internal Dictionary<string, T> data;
    public T this[string key] 
    {
        get => data[key];
        set
        {
            data[key].Dispose();
            data[key] = value;
        }
    }

    public ICollection<string> Keys => data.Keys;

    public ICollection<T> Values => data.Values;

    public int Count => data.Count;

    public bool IsReadOnly => false;

    internal GPUResources()
    {
        data = new();
    }

    public void Add(string key, T value)
    {
        data.Add(key, value);
    }

    public void Add(KeyValuePair<string, T> item)
    {
        data.Add(item.Key,item.Value);
    }

    public void Clear()
    {
        foreach (var v in Values)
            v.Dispose();
        data.Clear();
    }

    public bool Contains(KeyValuePair<string, T> item)
    {
        return data.Contains(item);
    }

    public bool ContainsKey(string key)
    {
        return data.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    public bool Remove(string key)
    {
        if(data.TryGetValue(key, out var v))
        {
            v.Dispose();
            data.Remove(key);
            return true;
        }
        return false;

    }

    public bool Remove(KeyValuePair<string, T> item)
    {
        return Remove(item.Key);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
    {
        return TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }
}
