using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets.Generators.SerializationGathering
{

    [Generator]
    public class GatherFormattersGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif 
            //Debug.WriteLine("Initalize code generator");
        }
        public void Execute(GeneratorExecutionContext context)
        {
            var projectAssembly = context.Compilation.Assembly;

            var gameClass =
                GetAllTypes(projectAssembly.GlobalNamespace)
                .Where(x => x.BaseType != null)
                .First(x => x.BaseType.OriginalDefinition.ToString() == "SoftTouch.Games.Game");

            var yamlFormatters =
                context
                .Compilation
                .SourceModule
                .ReferencedAssemblySymbols
                .Append(projectAssembly)
                .SelectMany(x => GetAllTypes(x.GlobalNamespace))
                .Where(x => x.AllInterfaces.Any(i => i.Name == "IYamlFormatter"))
                .Where(x => !x.OriginalDefinition.ToString().Contains("Generated"))
                .ToList();
            var memoryPackFormatters =
                context
                .Compilation
                .SourceModule
                .ReferencedAssemblySymbols
                .Append(projectAssembly)
                .SelectMany(x => GetAllTypes(x.GlobalNamespace))
                .Where(x => x.AllInterfaces.Any(i => i.Name == "IYamlFormatter"))
                .Where(x => !x.OriginalDefinition.ToString().Contains("Generated"))
                .ToList();
            var constructors = new StringBuilder();
            foreach(var y in yamlFormatters)
            {
                var fullname = y.OriginalDefinition.ToString();
                if (fullname.StartsWith("SoftTouch.Assets.Serialization.Yaml") && fullname.Contains("Vector") && fullname.Contains("<T>"))
                {
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<byte>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<sbyte>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<Half>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<short>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<ushort>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<float>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<int>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<uint>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<double>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<long>")).AppendLine("());");
                    constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", "<ulong>")).AppendLine("());");
                }
                else constructors.Append($"      GeneratedResolver.Register(new ").Append(fullname).AppendLine("());");
            }

            context.AddSource($"{gameClass.Name}.g.cs",
$@"
using System;
using VYaml;
using VYaml.Serialization;

 
namespace {gameClass.ContainingNamespace};
public partial class {gameClass.Name} 
{{
    static {gameClass.Name}()
    {{
        Console.WriteLine(""Hello world from generated {gameClass.Name} class"");
        {constructors}
    }}
}}
"

            );
        }
        
        private static IEnumerable<ITypeSymbol> GetAllTypes(INamespaceSymbol root)
        {
            foreach (var namespaceOrTypeSymbol in root.GetMembers())
            {
                if (namespaceOrTypeSymbol is INamespaceSymbol @namespace) foreach (var nested in GetAllTypes(@namespace)) yield return nested;

                else if (namespaceOrTypeSymbol is ITypeSymbol type)
                {
                    foreach( var t in type.GetTypeMembers())
                        yield return t;
                    yield return type;
                }
            }
        }
    }

    
}
