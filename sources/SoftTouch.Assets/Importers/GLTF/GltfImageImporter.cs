using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Zio;

namespace SoftTouch.Assets.Importers.GLTF;

public class GLTFImageImporter : AssetImporter<ImageAsset>
{
    static readonly string[] extensions = {".gltf",".glb"};
    public override string[] Extensions => extensions;
    public override IEnumerable<ImageAsset> ImportAsset(UPath assetPath, UPath path)
    {
        UPath rest = path;
        var dir = UPath.Root;
        while (true)
        {
            var first = rest.GetFirstDirectory2(out var tmp);
            dir /= first;
            rest = tmp;
            if (extensions.Contains(dir.GetExtensionWithDot()))
               break;
        }
        yield return new ImageAsset(assetPath, dir, rest);
    }
}

public static class UPathExtensions2
{
    public static string GetFirstDirectory2(this UPath path, out UPath remainingPath)
    {
        path.AssertNotNull();
        remainingPath = UPath.Empty;

        string firstDirectory;
        var fullname = path.FullName;
        var offset = path.IsRelative ? 0 : 1;
        var index = fullname.IndexOf(UPath.DirectorySeparator, offset);
        if (index < 0)
        {
            firstDirectory = fullname.Substring(offset, fullname.Length);
        }
        else
        {
            firstDirectory = fullname.Substring(offset, index - offset);
            if (index + 1 < fullname.Length)
            {
                remainingPath = fullname.Substring(index + 1);
            }
        }
        return firstDirectory;
    }
}