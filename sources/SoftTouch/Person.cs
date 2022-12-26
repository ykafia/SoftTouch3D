using MessagePack;

namespace SoftTouch;

[MessagePackObject]
public class Person
{
    [Key(0)]
    public string Name {get;set;} = "John Doe";
    [Key(1)]
    public int Age {get;set;} = 55;
}