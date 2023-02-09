using SoftTouch.Assets.Serialization.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;
using Utf8Json.Resolvers;

namespace SoftTouch.Assets.Serialization.Json;

public static class SoftTouchJsonOptions
{
    public static IJsonFormatterResolver Resolver => 
            CompositeResolver.Create(
                new IJsonFormatter[] { new UPathStringFormatter() },
                new IJsonFormatterResolver[] { JsonSerializer.DefaultResolver }
            );
}
