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
        public static string[] numTypes =
        {
            "sbyte",
            "byte",
            "ushort",
            "short",
            "Half",
            "uint",
            "int",
            "float",
            "ulong",
            "long",
            "double"
        };

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
                .Where(x => x.AllInterfaces.Any(i => i.Name == "IYamlSFTFormatter"))
                .Where(x => x.TypeKind != TypeKind.Interface)
                .Where(x => !x.OriginalDefinition.ToString().Contains("Generated"))
                .ToList();
            var memoryPackFormatters =
                context
                .Compilation
                .SourceModule
                .ReferencedAssemblySymbols
                .Append(projectAssembly)
                .SelectMany(x => GetAllTypes(x.GlobalNamespace))
                .Where(x => x.AllInterfaces.Any(i => i.Name == "IBinaryFormatter"))
                .Where(x => !x.IsAbstract && x.TypeKind == TypeKind.Class)
                .ToList();
            var constructors = new StringBuilder();
            foreach(var y in yamlFormatters)
            {
                var fullname = y.OriginalDefinition.ToString();
                if (y.AllInterfaces.Any( i => i.Name == "INumericsFormatter"))
                {
                    foreach(var nt in numTypes)
                        constructors.Append("       GeneratedResolver.Register(new ").Append(fullname.Replace("<T>", $"<{nt}>")).AppendLine("());");
                }
                else constructors.Append($"      GeneratedResolver.Register(new ").Append(fullname).AppendLine("());");
            }
            foreach (var y in memoryPackFormatters)
            {
                var fullname = y.OriginalDefinition.ToString();
                if (y.AllInterfaces.Any(i => i.Name == "INumericsFormatter"))
                {
                    foreach (var nt in numTypes)
                        constructors.Append("       MemoryPackFormatterProvider.Register(new ").Append(fullname.Replace("<T>", $"<{nt}>")).AppendLine("());");
                }
                else constructors.Append($"      MemoryPackFormatterProvider.Register(new ").Append(fullname).AppendLine("());");
            }

            context.AddSource($"{gameClass.Name}.g.cs",
$@"
using System;
using VYaml;
using VYaml.Serialization;
using MemoryPack;
using System.Runtime.CompilerServices;

 
namespace {gameClass.ContainingNamespace};
public static class SerializerInitializer 
{{
    [ModuleInitializer]
    public static void InitSerializer()
    {{
        {constructors}
        Console.WriteLine(""Iintialized serializers"");
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
