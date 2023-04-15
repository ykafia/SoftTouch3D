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

var watch = new Stopwatch();
var igame = typeof(IGame);
var iproc = typeof(IProcessor);
typeof(TypeLoaderExtensions).Assembly.GetLoadableTypes().Where(igame.IsAssignableFrom).ToList();

watch.Start();
typeof(TypeLoaderExtensions).Assembly.GetLoadableTypes().Where(iproc.IsAssignableFrom).ToList();
watch.Stop();

Console.WriteLine($"spent {watch.Elapsed} on querying types");
var game = new MyGame();
game.Run();

Console.WriteLine(YamlSerializer.SerializeToString(new Vector2D<float>(1, 56)));
Console.WriteLine(YamlSerializer.SerializeToString(new UPath("/home/youness")));
//game.Run();