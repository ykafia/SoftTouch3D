using SoftTouch.Assets;
using SoftTouch.Assets.FileSystems;
using SoftTouch.Assets.Importers.GLTF;
using Utf8Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;
using SoftTouch.Assets.Serialization.Json;

namespace SoftTouch.AssetsCompiler
{
    internal partial class CompilationCommand : RootCommand
    {

        private void CreateCompileCommand()
        {
            Console.WriteLine("Compiling assets");
            var outputPathOption = new Option<string>(new string[] { "--path", "-p" }, "Output folder for the generated compressed package")
            {
                IsRequired = true
            };
            var compileAssets = new Command("compile")
            {
                outputPathOption
            };

            compileAssets.SetHandler(CompileAssets, outputPathOption);

            AddCommand(compileAssets);
        }

        public void CompileAssets(string path)
        {
            var compiledfs = new SubFileSystem(pfs, pfs.ConvertPathFromInternal(path));
            var zpath = compiledfs.ConvertPathToInternal(compiledfs.ConvertPathFromInternal(path ?? "/") / "data.zip");
            var stream = ZipFile.Open(zpath, ZipArchiveMode.Update);
            var zipFs = new ZipArchiveFileSystem(stream);

            if (assetfs != null)
                foreach (var a in assetfs.EnumeratePaths("/", "*.st*", SearchOption.AllDirectories, SearchTarget.File))
                {
                    if (a.GetExtensionWithDot() == ".stimage")
                    {
                        var imageAsset =
                            JsonSerializer.Deserialize<ImageAsset>(
                                assetfs.ReadAllText(a),
                                SoftTouchJsonOptions.Resolver
                            );
                        var gltffs = new GltfFileSystem(resourcefs,imageAsset.Path);
                        // TODO : Do something with the loading

                    }
                }

            //var file = zipFs.CreateFile("/image");

        }
    }
}
