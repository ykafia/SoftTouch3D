using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using MemoryPack;


namespace SoftTouch.Benchmarks;

[MemoryPackable]
public partial struct Vec3
{
    [MemoryPackInclude]
    public float x;
    [MemoryPackInclude]
    public float y;
    [MemoryPackInclude]
    public float z;

    public Vec3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
[MemoryDiagnoser]
public class ReflectionBench
{
    public byte[] array;
    public ReflectionBench()
    {
        var vecs = new List<Vector3>
        {
            new(1,1,1),
            new(2,2,2),
            new(3,3,3),
            new(4,4,4)
        };
        array = MemoryPackSerializer.Serialize(vecs);
    }

    [Benchmark]
    public void DeserializeMemoryPackGeneric()
    {
        var s = MemoryPackSerializer.Deserialize<List<Vec3>>(array) ?? throw new Exception("Cannot deserialize with mempack generic");
    }
    [Benchmark]
    public void DeserializeMemoryPackType()
    {
        var s = (List<Vec3>)(MemoryPackSerializer.Deserialize(typeof(List<Vec3>), array.AsSpan()) ?? throw new Exception("Cannot deserialize with mempack generic"));
    }

    //[Benchmark]
    //public List<Vec3> DeserializeType()
    //{
    //    typeof(MemoryMarshal).GetMethod("Cast").
    //}

}
