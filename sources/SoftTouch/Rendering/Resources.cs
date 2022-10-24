using WGPU.NET;
namespace SoftTouch.Rendering;

public interface IGraphicResource{}

public interface ITransientResource : IGraphicResource{}

public interface IExternalResource : IGraphicResource{}


public class TrasientBuffer : ITransientResource
{
    Buffer buffer;

    public TrasientBuffer(Buffer buff)
    {
        buffer = buff;
    }
}
public class TrasientTexture : ITransientResource
{
    Texture texture;
    TextureView view;

    public TrasientTexture(Texture tex, TextureView v)
    {
        texture = tex;
        view = v;
    }
}

public class SwapResource : IExternalResource
{
    SwapChain swap;

    public TextureView SwapView => swap.GetCurrentTextureView();
}