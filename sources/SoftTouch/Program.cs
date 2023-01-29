using System;
using System.Linq;
using SoftTouch.Assets;
using SoftTouch.Graphics.WebGPU;
using System.IO;
using Zio.FileSystems;
using System.Collections.Generic;
// using SoftTouch.Assets.Serialization.Yaml;
using MessagePack;
using MessagePack.Resolvers;
using SoftTouch;
using Utf8Json;
using Silk.NET.Maths;
using Utf8Json.Resolvers;
using Zio;
using MemoryPack;
using SoftTouch.Assets.Serialization.MemoryPack;
using VYaml;
using VYaml.Serialization;
using SoftTouch.Assets.Serialization.Yaml;
using System.Text;

SoftYamlResolver.Init();

var yaml = YamlSerializer.Serialize(new Person());
Console.WriteLine(Encoding.UTF8.GetString(yaml.ToArray()));
var path = YamlSerializer.Deserialize<Person>(yaml);
Console.WriteLine($"path is {path}");


