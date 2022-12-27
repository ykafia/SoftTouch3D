using SoftTouch.Assets;
using SoftTouch.Assets.FileSystems;
using SpanJson;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.AssetsCompiler
{
    internal class CompilationCommand : RootCommand
    {
        PhysicalFileSystem pfs = new();
        SubFileSystem projectfs;
        ResourcesFileSystem resourcefs = new();
        AggregateFileSystem assetfs = new();
        public CompilationCommand()
        {
            Name = "coffret";
            Description = "Asset compilation tool for the SoftTouch game engine";

            projectfs = new SubFileSystem(pfs, pfs.ConvertPathFromInternal("./"));
            var pkgConfPath = projectfs.EnumeratePaths("/", "*.stpkg", SearchOption.TopDirectoryOnly, Zio.SearchTarget.File).FirstOrDefault(UPath.Empty);
            if (pkgConfPath != UPath.Empty || !pkgConfPath.IsNull)
            {
                var pkgText = new StreamReader(projectfs.OpenFile(pkgConfPath, FileMode.Open, FileAccess.Read)).ReadToEnd();
                var pkg = JsonSerializer.Generic.Utf16.Deserialize<PackageConfig>(pkgText);

                foreach (var r in pkg.Paths.ResourcesFolders)
                    resourcefs.AddFileSystem(new SubFileSystem(projectfs, new UPath(r).ToAbsolute()));
                foreach (var r in pkg.Paths.AssetsFolders)
                    assetfs.AddFileSystem(new SubFileSystem(projectfs, new UPath(r).ToAbsolute()));
            }
            //CreateCompileCommand();

            CreateListCommand();

            
            //renameCommand.Description = "Rename a file";
            //renameCommand.Handler = CommandHandler.Create<string, string>((input, output) =>
            //{
            //    File.Move(input, output);
            //});

            //rootCommand.Add(renameCommand);

        }

        private void CreateCompileCommand()
        {
            Console.WriteLine("List of files : ");
            var outputPathOption = new Option<string>(new string[] { "--path", "-p" }, "Output folder for the generated compressed package")
            {
                IsRequired = true
            };
            var compileAssets = new Command("compile")
            {
                outputPathOption
            };

            compileAssets.SetHandler(() => throw new NotImplementedException());

            AddCommand(compileAssets);
        }

        private void CreateListCommand()
        {
            var assetOption = new Option<bool>("--assets","list asset files");
            var resourceOption = new Option<bool>("--resources", "List resource files");

            var listAssets = new Command("list")
            {
               assetOption,
               resourceOption
            };
            listAssets.SetHandler(ListItems, assetOption, resourceOption);

            AddCommand(listAssets);
        }

        public void ListItems(bool asset, bool resources)
        {
            if (asset)
                assetfs.EnumerateItems("/", SearchOption.AllDirectories)
                .ToList().ForEach(x => Console.WriteLine(x));
            if (resources)
                resourcefs.EnumerateItems("/", SearchOption.AllDirectories)
                .ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
