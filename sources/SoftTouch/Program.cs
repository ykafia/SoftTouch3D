using System;
using SoftTouch;
using SoftTouch.Assets;
using Zio;
using Zio.FileSystems;
using System.Linq;
using SoftTouch.Assets.FileSystems;
using SoftTouch.Graphics.WGPU;
using VYaml.Serialization;
using Silk.NET.Maths;
using SoftTouch.ECS;
using System.Diagnostics;
using MemoryPack;

var watch = new Stopwatch();
var igame = typeof(IGame);
var iproc = typeof(IProcessor);
typeof(TypeLoaderExtensions).Assembly.GetLoadableTypes().Where(igame.IsAssignableFrom).ToList();

watch.Start();
typeof(TypeLoaderExtensions).Assembly.GetLoadableTypes().Where(iproc.IsAssignableFrom).ToList();
watch.Stop();

Console.WriteLine($"spent {watch.Elapsed} on querying types");

var game = new MyGame();

var state = GraphicsState.GetOrCreate();
BufferRWTest.Test(state);
//game.Run();

var bytes = MemoryPackSerializer.Serialize(new Vector2D<float>(15, 17));
(float, float) tuple = MemoryPackSerializer.Deserialize<(float,float)>(bytes);
Console.WriteLine($"{{ {tuple.Item1} , {tuple.Item2} }}");
Console.WriteLine(YamlSerializer.SerializeToString(new Vector2D<float>(1, 56)));
Console.WriteLine(YamlSerializer.SerializeToString(new UPath("/home/youness")));
//game.Run();