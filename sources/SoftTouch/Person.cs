using MemoryPack;
using MessagePack;
using Silk.NET.Maths;
using VYaml.Annotations;
using Zio;

namespace SoftTouch;

[YamlObject]
[MemoryPackable]
public partial class Person
{
    [MemoryPackInclude]
    public string Name { get; set; } = "John Doe";
    [MemoryPackInclude]
    public int Age { get; set; } = 55;
    [MemoryPackInclude]
    public Vector2D<float> Position { get; set; } = new(1, 20);
    [MemoryPackInclude]
    public UPath? Path { get; set; } = new("/MyPath/Something");

    public override string ToString()
    {
        return $"{Name}; {Age}; [{Position.X}, {Position.Y}]";
    }
}