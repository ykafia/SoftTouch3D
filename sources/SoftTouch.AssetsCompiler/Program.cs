// See https://aka.ms/new-console-template for more information
using Zio.FileSystems;
using Zio;
using System.CommandLine;
using SoftTouch.AssetsCompiler;
using Utf8Json;
using SoftTouch.Assets.Serialization.MemoryPack;
using SoftTouch.Assets.Serialization.Json;

namespace SoftTouch.Assets.CompilerApp;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new CompilationCommand();
        return await rootCommand.InvokeAsync(args);

    }
}
