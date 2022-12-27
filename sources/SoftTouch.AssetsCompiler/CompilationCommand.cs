using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio.FileSystems;

namespace SoftTouch.AssetsCompiler
{
    internal class CompilationCommand : RootCommand
    {
        PhysicalFileSystem pfs = new();
        AggregateFileSystem afs = new();
        public CompilationCommand()
        {
            Name = "coffret";
            Description = "Asset compilation tool for the SoftTouch game engine";

            //AddOption(new Option<string>("--path", "path to compile the game asset"));

            var compileAssets = new Command("compile")
            {
                new Option<string>(new string[]{"--path", "-p"}, "Output folder for the generated compressed package")
                {
                    IsRequired = true
                }
            };

            AddCommand(compileAssets);


            var listAssets = new Command("list")
            {
                new Option<bool>(new string[]{"--assets", "-a"}, "List assets created")
                {
                    IsRequired = false
                },
                new Option<bool>(new string[]{"--resources", "-r"}, "List existing resources")
                {
                    IsRequired = false
                }

            };
            //renameCommand.Description = "Rename a file";
            //renameCommand.Handler = CommandHandler.Create<string, string>((input, output) =>
            //{
            //    File.Move(input, output);
            //});

            //rootCommand.Add(renameCommand);

        }
    }
}
