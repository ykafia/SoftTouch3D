namespace SoftTouch;
using System.IO;

using Silk.NET.Direct3D.Compilers;

public class ShaderProgram
{
    public ShaderProgram(string name)
    {
    }
    public static byte[] GetTriangleVert()
    {
        return File.ReadAllBytes(@"D:\codeProj\csproj\DXDebug\sources\SoftTouch\Shaders\GLSL\triangle\tri.vert.spv");
    }
    public static byte[] GetTriangleFrag()
    {
        return File.ReadAllBytes(@"D:\codeProj\csproj\DXDebug\sources\SoftTouch\Shaders\GLSL\triangle\tri.frag.spv");
    }
}