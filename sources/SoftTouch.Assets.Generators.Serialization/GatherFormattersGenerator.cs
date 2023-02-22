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

            
            var assemblies =
                context
                .Compilation
                .SourceModule
                .ReferencedAssemblySymbols
                .Append(projectAssembly)
                .Where(x => x.Name.Contains("SoftTouch"))
                .SelectMany(x => GetAllTypes(x.GlobalNamespace))
                .Where(x => x.BaseType != null)
                .Where(x => x.BaseType.Name.Contains("MemoryPackFormatter"))
                .Select(x => x.Name)
                .ToList();

            context.AddSource("Data.g.cs",
$@"
namespace SoftTouch.Generated;
public class TypeNames 
{{
    public static string[] names = {{ ""{string.Join("\",\"", assemblies)}"" }};
}}
"

            );

            //var types = context.Compilation.SourceModule.ReferencedAssemblySymbols.SelectMany(a =>
            //{
            //    try
            //    {
            //        var main = a.Identity.Name.Split('.').Aggregate(a.GlobalNamespace, (s, c) => s.GetNamespaceMembers().Single(m => m.Name.Equals(c)));

            //        return GetAllTypes(main);
            //    }
            //    catch
            //    {
            //        return Enumerable.Empty<ITypeSymbol>();
            //    }
            //});

            //var properties = types.Where(t => t.TypeKind == TypeKind.Interface && t.DeclaredAccessibility == Accessibility.Public).Select(t => new
            //{
            //    Interface = t,
            //    Properties = t.GetMembers()
            //});
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
