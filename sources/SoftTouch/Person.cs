using MessagePack;
using Silk.NET.Maths;
using VYaml.Annotations;
using Zio;

namespace SoftTouch;

[YamlObject]
public partial class Person
{
    public string Name { get; set; } = "John Doe";
    public int Age { get; set; } = 55;
    public Vector2D<float> Position { get; set; } = new(1, 20);
    public UPath Path { get; set; } = new("/MyPath/Something");

    public override string ToString()
    {
        return $"{Name}; {Age}; [{Position.X}, {Position.Y}], {Path}";
    }
}