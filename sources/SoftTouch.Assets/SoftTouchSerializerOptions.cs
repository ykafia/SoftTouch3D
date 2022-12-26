using MessagePack;

namespace SoftTouch.Assets;

public class SoftTouchSerializerOptions
{
    public static MessagePackSerializerOptions Options = MessagePackSerializer.DefaultOptions.WithResolver(SoftTouchResolver.Instance);
}