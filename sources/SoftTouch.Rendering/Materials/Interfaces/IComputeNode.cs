namespace SoftTouch.Rendering.Materials;


public interface IComputeNode
{
    public interface IComputeNode
    {
        IEnumerable<IComputeNode> GetChildren(object context = null);
        // ShaderSource GenerateShaderSource(ShaderGeneratorContext context, MaterialComputeColorKeys baseKeys);
    }
}