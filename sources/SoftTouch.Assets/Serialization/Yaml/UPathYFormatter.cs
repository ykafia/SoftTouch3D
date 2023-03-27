using Silk.NET.Maths;
using System;
using System.Buffers.Text;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml;
using VYaml.Emitter;
using VYaml.Parser;
using VYaml.Serialization;
using Zio;
using SoftTouch.Core.Serialization;

namespace SoftTouch.Assets.Serialization.Yaml;

public class UPathYFormatter : IYamlSFTFormatter<UPath>
{
    public UPath Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        if (!parser.TryGetCurrentTag(out var tag) && tag.ToString() != "!path")
            throw new Exception("Not a UPath");
        parser.SkipAfter(ParseEventType.MappingStart);
        context.DeserializeWithAlias<string>(ref parser);
        var x = context.DeserializeWithAlias<string>(ref parser);
        return new(x);
    }

    public void Serialize(ref Utf8YamlEmitter emitter, UPath value, YamlSerializationContext context)
    {
        emitter.Tag(Encoding.UTF8.GetBytes("!path"));
        emitter.BeginMapping();
        context.Serialize(ref emitter, "fullname");
        context.Serialize(ref emitter, value.FullName);
        emitter.EndMapping();
    }
}
