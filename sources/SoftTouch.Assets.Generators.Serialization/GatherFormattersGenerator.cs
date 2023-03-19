using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                .Where(x => x.BaseType.OriginalDefinition.ToString() == "SoftTouch.Games.Game")
                .First();
            
            var assemblies =
                context
                .Compilation
                .SourceModule
                .ReferencedAssemblySymbols
                .Append(projectAssembly)
                .Where(x => x.Name.Contains("SoftTouch"))
                .SelectMany(x => GetAllTypes(x.GlobalNamespace))
                .Where(x => x.AllInterfaces.Any(i => i.Name == "IYamlFormatter"))
                //.Where(x => x.BaseType != null)
                //.Where(x => x.BaseType.Name.Contains("MemoryPackFormatter"))
                //.Select(x => x.Name)
                .ToList();

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
