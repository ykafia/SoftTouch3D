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

var game = new MyGame();

Console.WriteLine(YamlSerializer.SerializeToString(new Vector2D<float>(1, 56)));
Console.WriteLine(YamlSerializer.SerializeToString(new UPath("/home/youness")));
//game.Run();