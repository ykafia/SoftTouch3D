using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYaml.Emitter;
using VYaml.Parser;
using VYaml.Serialization;

namespace SoftTouch.Graphics.Serialization.Yaml;

public class Random
{
    public string Value { get; set; }
}

public class RandomYamlSerializer : IYamlFormatter<Random>
{
    public Random Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        if (parser.TryGetCurrentTag(out var tag) && tag.Handle == "random")
        {
            parser.SkipAfter(ParseEventType.MappingStart);
            var field = parser.GetScalarAsString();
            var val = parser.GetScalarAsString();
            return new Random { Value = val! };
        }
        else throw new Exception("Data cannot be parsed as Random");
        
    }

    public void Serialize(ref Utf8YamlEmitter emitter, Random value, YamlSerializationContext context)
    {
        emitter.Tag(Encoding.UTF8.GetBytes("random"));
        emitter.BeginMapping();
        emitter.WriteString("value");
        emitter.WriteString(value.Value);
        emitter.EndMapping();
    }
}
