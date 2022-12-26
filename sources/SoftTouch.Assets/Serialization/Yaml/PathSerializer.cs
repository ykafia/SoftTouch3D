using VYaml.Parser;
using VYaml.Serialization;
using Zio;

namespace SoftTouch.Assets.Serialization.Yaml;




public class PathYamlSerializer : IYamlFormatter<UPath>
{
    public UPath Deserialize(ref YamlParser parser, YamlDeserializationContext context)
    {
        parser.TryGetCurrentTag(out var tag);
        var result = parser.GetScalarAsString();
        return new UPath(result ?? "").ToRelative();
    }
}