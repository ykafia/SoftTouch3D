// See https://aka.ms/new-console-template for more information
using Zio.FileSystems;
using Zio;

namespace SoftTouch.Assets.CompilerApp;

public class Program
{
    public static void Main(string[] args)
    {
        var fs = new PhysicalFileSystem();
        var sub = new SubFileSystem(fs, fs.ConvertPathFromInternal("./"));
        sub.EnumerateItems("/", SearchOption.TopDirectoryOnly)
            .ToList()
            .ForEach(x => Console.WriteLine(x));
    }
}
