using SoftTouch.Assets;
using SoftTouch.Assets.FileSystems;
using SoftTouch.Assets.Importers.GLTF;
using Utf8Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;
using VYaml.Serialization;

namespace SoftTouch.AssetsCompiler
{
    internal partial class CompilationCommand : RootCommand
    {
        PhysicalFileSystem pfs = new();
        SubFileSystem projectfs;
        ResourcesFileSystem resourcefs = new();
        SubFileSystem? assetfs;
        public CompilationCommand()
        {
            Name = "coffret";
            Description = "Asset compilation tool for the SoftTouch game engine";


            projectfs = new SubFileSystem(pfs, pfs.ConvertPathFromInternal("./"));
            var pkgConfPath = projectfs.EnumeratePaths("/", "*.stpkg", SearchOption.TopDirectoryOnly, Zio.SearchTarget.File).FirstOrDefault(UPath.Empty);
            if (pkgConfPath != UPath.Empty || !pkgConfPath.IsNull)
            {
                var pkgText = new StreamReader(projectfs.OpenFile(pkgConfPath, FileMode.Open, FileAccess.Read)).ReadToEnd();
                var pkg = JsonSerializer.Deserialize<PackageConfig>(pkgText);

                foreach (var r in pkg.Paths.ResourcesFolders)
                    resourcefs.AddFileSystem(new SubFileSystem(projectfs, new UPath(r).ToAbsolute()));
                foreach (var r in pkg.Paths.AssetsFolders)
                    assetfs = new SubFileSystem(projectfs,new UPath(r).ToAbsolute());
                    //assetfs.AddFileSystem(new SubFileSystem(projectfs, new UPath(r).ToAbsolute()));
            }
            CreateCompileCommand();
            CreateAddAsset();
            CreateListCommand();

        }

        

        private void CreateListCommand()
        {
            var assetOption = new Option<bool>("--assets", "list asset files");
            var resourceOption = new Option<bool>("--resources", "List resource files");

            var listAssets = new Command("list")
            {
               assetOption,
               resourceOption
            };
            listAssets.SetHandler(ListItems, assetOption, resourceOption);

            AddCommand(listAssets);
        }

        public void CreateAddAsset()
        {
            var imageOpt = new Option<bool>("--image", "add as image");
            var modelOpt = new Option<bool>("--model", "add as model");
            var file = new Option<string>("--file", "path of the file") { IsRequired = true };
            var path = new Option<string>("--path", "path of the file");

            var addAsset = new Command("add")
            {
                file,
                path,
                imageOpt,
                modelOpt
            };


            addAsset.SetHandler(AddAsset, file, path, imageOpt, modelOpt);

            AddCommand(addAsset);
        }

        public void AddAsset(string file, string path, bool imageOpt, bool modelOpt)
        {
            if (imageOpt && modelOpt)
            {
                Console.WriteLine("Can't guess which type");
                Environment.Exit(1);
            }
            if (imageOpt)
            {
                Console.WriteLine("Adding image asset");
                var asset = new GLTFImageImporter().Import(path ?? "/", file).First();
                var serialized = YamlSerializer.SerializeToString(asset);
                Console.WriteLine(serialized);
                var fileName = (asset.AssetPath != UPath.Empty ? asset.AssetPath : ((UPath)file).GetNameWithoutExtension() ?? "") + ".stimage";
                assetfs?.WriteAllText(path ?? UPath.Root / fileName, serialized);
            }
            if (modelOpt)
            {
                //new GLTFImageImporter().Import(path ?? UPath.Root, file);
            }
        }

        public void ListItems(bool asset, bool resources)
        {
            if (asset)
                assetfs?.EnumerateItems("/", SearchOption.AllDirectories)
                .ToList().ForEach(x => Console.WriteLine(x));
            if (resources)
                resourcefs.EnumerateItems("/", SearchOption.AllDirectories)
                .ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
