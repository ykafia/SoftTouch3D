using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftTouch.Assets.Generators.SerializationGathering
{

    [Generator]
    public class LibrarySerializerGathererSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            
        }
        public void Execute(GeneratorExecutionContext context)
        {
            var gameClass = context.Compilation.GetTypeByMetadataName("SoftTouch.Games.Game");
            var types = context.Compilation.SourceModule.ReferencedAssemblySymbols.SelectMany(a =>
            {
                try
                {
                    var main = a.Identity.Name.Split('.').Aggregate(a.GlobalNamespace, (s, c) => s.GetNamespaceMembers().Single(m => m.Name.Equals(c)));

                    return GetAllTypes(main);
                }
                catch
                {
                    return Enumerable.Empty<ITypeSymbol>();
                }
            });

            var properties = types.Where(t => t.TypeKind == TypeKind.Interface && t.DeclaredAccessibility == Accessibility.Public).Select(t => new
            {
                Interface = t,
                Properties = t.GetMembers()
            });
        }

        
        private static IEnumerable<ITypeSymbol> GetAllTypes(INamespaceSymbol root)
        {
            foreach (var namespaceOrTypeSymbol in root.GetMembers())
            {
                if (namespaceOrTypeSymbol is INamespaceSymbol @namespace) foreach (var nested in GetAllTypes(@namespace)) yield return nested;

                else if (namespaceOrTypeSymbol is ITypeSymbol type) yield return type;
            }
        }
    }



}
