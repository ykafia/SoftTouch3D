using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using MessagePack;
using MessagePack.Resolvers;
using Silk.NET.Maths;
using SoftTouch.Assets;
using SoftTouch.Components;

namespace SoftTouch
{

    public class Program
    {

        public static void Main(string[] _)
        {
            Console.WriteLine("Hello world");
            // var resolver = MessagePack.Resolvers.CompositeResolver.Create(
            //     SoftTouchResolver.Instance,
            //     StandardResolver.Instance
            // );
            // var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
            // MessagePackSerializer.DefaultOptions = options;

            // MessagePackSerializer.Serialize(new Transform(){Position = Vector3D<float>.One});
            // var g = new Game();
            // g.Run();
        }
    }
}