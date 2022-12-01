using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace SoftTouch
{

    public class Program
    {

        public static void Main(string[] _)
        {
            TrySerialized();
            TrySerialized();
            // var g = new Game();
            // g.Run();
        }
        public static void TrySerialized()
        {
            var watch = new Stopwatch();
            var tr = new Components.Transform() { Position = new(1, 1, 1) };

            watch.Start();
            var serialized = MessagePack.MessagePackSerializer.Serialize(tr);
            watch.Stop();
            Console.WriteLine($"msgpack serialized = {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var json = JsonSerializer.Serialize(tr);
            watch.Stop();
            Console.WriteLine($"json serialized = {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var dser = MessagePack.MessagePackSerializer.Deserialize<Components.Transform>(serialized);
            watch.Stop();
            Console.WriteLine($"msgpack deserialized = {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var dsrjson = JsonSerializer.Deserialize<Components.Transform>(json);
            watch.Stop();
            Console.WriteLine($"json deserialized = {watch.Elapsed}");
            watch.Reset();
            watch.Start();
        }
    }
}